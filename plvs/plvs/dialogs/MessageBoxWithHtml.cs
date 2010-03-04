﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Atlassian.plvs.dialogs {
    public partial class MessageBoxWithHtml : Form {

        public const string EXCEPTION_LINK_TAG = "exceptionlink:";

        public delegate void ExceptionLinkCallback(string tag);

        private ExceptionLinkCallback callback;
        private Action copyToClipboardClicked;

        public static void showError(string title, string html, Action copyToClipboardClicked, ExceptionLinkCallback callback) {
            MessageBoxWithHtml box = new MessageBoxWithHtml
                                     {
                                         Text = title,
                                         labelIcon = {Image = SystemIcons.Error.ToBitmap()},
                                         copyToClipboardClicked = copyToClipboardClicked,
                                         callback = callback
                                     };
            box.webContent.DocumentText = getHtml(box.labelIcon.Font, html);
//            box.webContent.IsWebBrowserContextMenuEnabled = true;
            box.ShowDialog();
        }

        private static string getHtml(Font font, string html) {
            string fontFamily = font.FontFamily.Name;
            return 
                "<html>\r\n<body style=\"margin:0;padding:0;font-family:" + fontFamily + ";font-size:12px;\">\r\n" 
                + html + "\r\n</body>\r\n</html>\r\n";
        }

        private MessageBoxWithHtml() {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }

        private void buttonOk_Click(object sender, EventArgs e) {
            Close();
        }

        private void webContent_Navigating(object sender, WebBrowserNavigatingEventArgs e) {
            if (e.Url.Equals("about:blank")) {
                return;
            }
            e.Cancel = true;
            string url = e.Url.ToString();
            if (url.StartsWith(EXCEPTION_LINK_TAG)) {
                if (callback != null) {
                    callback(url.Substring(EXCEPTION_LINK_TAG.Length));
                }
            } else {
                try {
                    Process.Start(url);
                    // ReSharper disable EmptyGeneralCatchClause
                } catch {
                    // ReSharper restore EmptyGeneralCatchClause
                }
            }
        }

        private void linkCopyToClipboard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            copyToClipboardClicked();
        }

        private void messageBoxWithHtmlKeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Escape) {
                Close();
            }
        }
    }
}
