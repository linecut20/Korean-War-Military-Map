using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

public class ShareScript : MonoBehaviour
{
    private const string SENDER_EMAIL = "linecut20@gmail.com";
    private const string SENDER_PASSWORD = "xwxfkyygehkdctjw";

    public GameObject mainPanel;
    public GameObject sharePanel;
    public GameObject textArea;
    public GameObject btnConfirm;
    public GameObject btnCancel;
    public GameObject infoText;
    public GameObject emailInputArea;

    public ProjectManager pm;

    void Start()
    {
        pm = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ConfirmButtonTouchedFunc()
    {
        string email = textArea.GetComponent<TMPro.TMP_InputField>().text;

        if (email.Length != 0)
        {
            if (!Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                infoText.GetComponent<TMPro.TextMeshProUGUI>().text = "이메일 형식이 올바르지 않습니다.";
            }
            else
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(SENDER_EMAIL);
                mail.To.Add(email);
                mail.Subject = "군사지도 공유 (전쟁기념관)";
                mail.Body = "전쟁기념관 군사지도 공유 메일입니다.";

                //mail에 이미지 추가
                Attachment attachment = new Attachment(pm.mapData["image_path"]);
                mail.Attachments.Add(attachment);

                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                smtpServer.Port = 587;
                smtpServer.Credentials = new System.Net.NetworkCredential(SENDER_EMAIL, SENDER_PASSWORD) as ICredentialsByHost;
                smtpServer.EnableSsl = true;
                ServicePointManager.ServerCertificateValidationCallback =
                    delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                    { return true; };
                smtpServer.Send(mail);

                sharePanel.SetActive(false);
                mainPanel.SetActive(true);
            }


        }
        else
        {
            infoText.GetComponent<TMPro.TextMeshProUGUI>().text = "이메일을 입력해주세요.";

        }
    }

    public void CancelButtonTouchedFunc()
    {
        sharePanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void OnEmailInputAreaTouched()
    {
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.EmailAddress);
    }

    public void ClearInfoText()
    {
        infoText.GetComponent<TMPro.TextMeshProUGUI>().text = "";
    }
}
