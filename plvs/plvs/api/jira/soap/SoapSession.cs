﻿using System;
using System.Collections.Generic;
using Atlassian.plvs.Atlassian.plvs.api.soap.service;

namespace Atlassian.plvs.api.jira.soap {
    public class SoapSession {
        private readonly string url;
        public string Token { get; private set; }
        private readonly JiraSoapServiceService service = new JiraSoapServiceService();

        public SoapSession(string u) {
            url = u + "/rpc/soap/jirasoapservice-v2";
            service.Url = url;
        }

        public void login(string userName, string password) {
            try {
                Token = service.login(userName, password);
            }
            catch (Exception e) {
                throw new LoginException(e);
            }
        }

        public List<JiraProject> getProjects() {
            RemoteProject[] pTable = service.getProjectsNoSchemes(Token);
            List<JiraProject> list = new List<JiraProject>();
            foreach (RemoteProject p in pTable) {
                list.Add(new JiraProject(int.Parse(p.id), p.key, p.name));
            }
            return list;
        }

        public List<JiraSavedFilter> getSavedFilters() {
            RemoteFilter[] fTable = service.getSavedFilters(Token);
            List<JiraSavedFilter> list = new List<JiraSavedFilter>();
            foreach (RemoteFilter f in fTable) {
                list.Add(new JiraSavedFilter(int.Parse(f.id), f.name));
            }
            return list;
        }

        public string createIssue(JiraIssue issue) {
            RemoteIssue ri = new RemoteIssue
                             {
                                 project = issue.ProjectKey,
                                 type = issue.IssueTypeId.ToString(),
                                 priority = issue.PriorityId.ToString(),
                                 summary = issue.Summary,
                                 description = issue.Description,
                             };
            if (issue.Assignee != null) {
                ri.assignee = issue.Assignee;
            }

            if (issue.Components != null && issue.Components.Count > 0) {
                RemoteComponent[] components = service.getComponents(Token, issue.ProjectKey);
                List<RemoteComponent> comps = new List<RemoteComponent>();
                for (int i = 0; i < issue.Components.Count; ++i) {
                    foreach (RemoteComponent component in components) {
                        // fixme: a bit problematic part. What if two components have the same name?
                        // I suppose JiraIssue class has to be fixed, but that would require more problematic
                        // construction of it during server query
                        if (!component.name.Equals(issue.Components[i])) {
                            continue;
                        }
                        comps.Add(component);
                        break;
                    }
                }
                ri.components = comps.ToArray();
            }

            RemoteVersion[] versions = service.getVersions(Token, issue.ProjectKey);
            
            if (issue.Versions != null && issue.Versions.Count > 0) {
                List<RemoteVersion> vers = new List<RemoteVersion>();
                for (int i = 0; i < issue.Versions.Count; ++i) {
                    foreach (RemoteVersion version in versions) {
                        // fixme: a bit problematic part. same as for components
                        if (!version.name.Equals(issue.Versions[i])) {
                            continue;
                        }
                        vers.Add(version);
                        break;
                    }
                }
                ri.affectsVersions = vers.ToArray();
            }

            if (issue.FixVersions != null && issue.FixVersions.Count > 0) {
                List<RemoteVersion> vers = new List<RemoteVersion>();
                for (int i = 0; i < issue.FixVersions.Count; ++i) {
                    foreach (RemoteVersion version in versions) {
                        // fixme: a bit problematic part. same as for components
                        if (!version.name.Equals(issue.FixVersions[i])) {
                            continue;
                        }
                        vers.Add(version);
                        break;
                    }
                }
                ri.fixVersions = vers.ToArray();
            }

            RemoteIssue createdIssue = service.createIssue(Token, ri);
            return createdIssue.key;
        }

        public void addComment(JiraIssue issue, string comment) {
            service.addComment(Token, issue.Key, new RemoteComment {body = comment});
        }

        public class LoginException : Exception {
            public LoginException(Exception e) : base("Login failed", e) {}
        }

        public object getIssueSoapObject(string key) {
            return service.getIssue(Token, key);
        }

        public JiraNamedEntity getSecurityLevel(string key) {
            try {
                RemoteSecurityLevel securityLevel = service.getSecurityLevel(Token, key);
                return securityLevel == null ? null : new JiraNamedEntity(int.Parse(securityLevel.id), securityLevel.name, null);
            } catch (Exception) {
                return null;
            }
        }

        public List<JiraNamedEntity> getIssueTypes() {
            return createEntityListFromConstants(service.getIssueTypes(Token));
        }

        public List<JiraNamedEntity> getSubtaskIssueTypes() {
            return createEntityListFromConstants(service.getSubTaskIssueTypes(Token));
        }

        public List<JiraNamedEntity> getIssueTypes(JiraProject project) {
            return createEntityListFromConstants(service.getIssueTypesForProject(Token, project.Id.ToString()));
        }

        public List<JiraNamedEntity> getPriorities() {
            return createEntityListFromConstants(service.getPriorities(Token));
        }

        public List<JiraNamedEntity> getStatuses() {
            return createEntityListFromConstants(service.getStatuses(Token));
        }

        public List<JiraNamedEntity> getComponents(JiraProject project) {
            return createEntityList(service.getComponents(Token, project.Key));
        }

        public List<JiraNamedEntity> getVersions(JiraProject project) {
            return createEntityList(service.getVersions(Token, project.Key));
        }

        public List<JiraNamedEntity> getResolutions() {
            return createEntityListFromConstants(service.getResolutions(Token));
        }

        public List<JiraNamedEntity> getActionsForIssue(JiraIssue issue) {
            RemoteNamedObject[] actions = service.getAvailableActions(Token, issue.Key);
            List<JiraNamedEntity> list = new List<JiraNamedEntity>();
            foreach (RemoteNamedObject action in actions) {
                list.Add(new JiraNamedEntity(int.Parse(action.id), action.name, null));
            }
            return list;
        }

        public List<JiraField> getFieldsForAction(JiraIssue issue, int id) {
            RemoteField[] fields = service.getFieldsForAction(Token, issue.Key, id.ToString());
            List<JiraField> list = new List<JiraField>();
            foreach (RemoteField field in fields) {
                list.Add(new JiraField(field.id, field.name));
            }
            return list;
        }

        public void runIssueActionWithoutParams(JiraIssue issue, int id) {
            service.progressWorkflowAction(Token, issue.Key, id.ToString(), null);
        }

        public void runIssueActionWithParams(JiraIssue issue, int id, ICollection<JiraField> fields, string comment) {
            if (fields == null || fields.Count == 0) {
                throw new Exception("Field values must not be empty");
            }
            List<RemoteFieldValue> fieldValues = new List<RemoteFieldValue>();
            foreach (JiraField field in fields) {
                if (field.Values == null) continue;

                RemoteFieldValue fv = new RemoteFieldValue {id = field.Id, values = field.Values.ToArray()};
                fieldValues.Add(fv);
            }
            service.progressWorkflowAction(Token, issue.Key, id.ToString(), fieldValues.ToArray());
            if (!string.IsNullOrEmpty(comment)) {
                service.addComment(Token, issue.Key, new RemoteComment { body = comment });
            }
        }

        public void logWorkAndAutoUpdateRemaining(string key, string timeSpent, DateTime startDate) {
            RemoteWorklog worklog = new RemoteWorklog { timeSpent = timeSpent, startDate = startDate };
            service.addWorklogAndAutoAdjustRemainingEstimate(Token, key, worklog);
        }

        public void logWorkAndLeaveRemainingUnchanged(string key, string timeSpent, DateTime startDate) {
            RemoteWorklog worklog = new RemoteWorklog { timeSpent = timeSpent, startDate = startDate };
            service.addWorklogAndRetainRemainingEstimate(Token, key, worklog);
        }

        public void logWorkAndUpdateRemainingManually(string key, string timeSpent, DateTime startDate, string remainingEstimate) {
            RemoteWorklog worklog = new RemoteWorklog { timeSpent = timeSpent, startDate = startDate };
            service.addWorklogWithNewRemainingEstimate(Token, key, worklog, remainingEstimate);
        }

        public void updateIssue(string key, ICollection<JiraField> fields) {
            List<RemoteFieldValue> fieldValues = new List<RemoteFieldValue>();
            foreach (JiraField field in fields) {
                RemoteFieldValue fv = new RemoteFieldValue {id = field.Id, values = field.Values.ToArray()};
                fieldValues.Add(fv);
            }
            service.updateIssue(Token, key, fieldValues.ToArray());
        }

        public void uploadAttachment(string key, string name, byte[] attachment) {
            service.addBase64EncodedAttachmentsToIssue(Token, key, new[] {name}, new[] {Convert.ToBase64String(attachment)});
        }

        #region private parts

        private static List<JiraNamedEntity> createEntityList(IEnumerable<AbstractNamedRemoteEntity> entities) {
            List<JiraNamedEntity> list = new List<JiraNamedEntity>();
            foreach (AbstractNamedRemoteEntity val in entities) {
                list.Add(new JiraNamedEntity(int.Parse(val.id), val.name, null));
            }
            return list;
        }

        private static List<JiraNamedEntity> createEntityListFromConstants(IEnumerable<AbstractRemoteConstant> vals) {
            List<JiraNamedEntity> list = new List<JiraNamedEntity>();
            foreach (AbstractRemoteConstant val in vals) {
                list.Add(new JiraNamedEntity(int.Parse(val.id), val.name, val.icon));
            }
            return list;
        }

        #endregion
    }
}