using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System;

public class ShareScript : MonoBehaviour
{
    private const string SENDER_EMAIL = "krwarmap@gmail.com";
    private const string SENDER_PASSWORD = "wisfxvdhxdldrmjv";


    public GameObject imageArea;
    public GameObject canvas;
    public GameObject sharePanel;
    public GameObject loadingPanel;
    public GameObject completePanel;
    public GameObject errorPanel;
    public GameObject textArea;
    public GameObject btnConfirm;
    public GameObject btnCancel;
    public GameObject infoText;
    public GameObject emailInputArea;
    public GameObject domainDropdown;
    public GameObject domainInputArea;
    private string basePath = Application.streamingAssetsPath;

    public ProjectManager pm;

    private string email;

    void Start()
    {
        pm = GameObject.Find("ProjectManager").GetComponent<ProjectManager>();
        imageArea = GameObject.Find("ImageArea");
        canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ConfirmButtonTouchedFunc();
        }
    }

    public void ConfirmButtonTouchedFunc()
    {
        CloseKeyboard();

        string domain = "";
        if (domainDropdown.GetComponent<TMPro.TMP_Dropdown>().value == 5)
        {
            domain = domainInputArea.GetComponent<TMPro.TMP_InputField>().text;
        }
        else
        {
            domain = domainDropdown.GetComponent<TMPro.TMP_Dropdown>().options[domainDropdown.GetComponent<TMPro.TMP_Dropdown>().value].text;
        }

        email = textArea.GetComponent<TMPro.TMP_InputField>().text + "@" + domain;

        if (email.Length != 0)
        {
            if (!Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                infoText.GetComponent<TMPro.TextMeshProUGUI>().text = "이메일 형식이 올바르지 않습니다.";
            }
            else
            {
                SendEmail();
            }
        }
        else
        {
            infoText.GetComponent<TMPro.TextMeshProUGUI>().text = "이메일을 입력해주세요.";
        }
    }

    private void SendEmail()
    {
        //prefabs의 LoadingPanel을 추가
        GameObject lp = Instantiate(loadingPanel, canvas.transform);
        lp.transform.SetAsLastSibling();

        Invoke("SendEmailFunc", 0.5f);
    }

    private void SendEmailFunc()
    {
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(SENDER_EMAIL);
        mail.To.Add(email);
        mail.Subject = "군사지도 공유 (전쟁기념관)";
        mail.Body = "전쟁기념관 군사지도 공유 메일입니다.";

        //mail에 이미지를 추가        
        Attachment attachment = new Attachment(basePath + pm.mapData["share_image_path"]);
        // Attachment attachment = new Attachment(basePath + pm.mapData["image_path"]);
        mail.Attachments.Add(attachment);

        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new System.Net.NetworkCredential(SENDER_EMAIL, SENDER_PASSWORD) as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };

        try
        {
            smtpServer.Send(mail);
            Destroy(GameObject.Find("Loading Panel(Clone)"));
            CompleteDialog();
        }
        catch (Exception e)
        {
            Debug.Log(e);
            Destroy(GameObject.Find("Loading Panel(Clone)"));
            ErrorDialog();
        }
    }

    public void CancelButtonTouchedFunc()
    {
        CloseKeyboard();

        //sharePanel 삭제
        Destroy(sharePanel);
    }

    public void OnEmailInputAreaTouched()
    {
        OnInputTouch();
    }

    public void ClearInfoText()
    {
        infoText.GetComponent<TMPro.TextMeshProUGUI>().text = "";
    }

    private void CompleteDialog()
    {
        CloseKeyboard();
        //완료 안내문 
        GameObject newPref = Instantiate(completePanel, sharePanel.transform);
        newPref.transform.SetAsLastSibling();
    }

    private void ErrorDialog()
    {
        //실패 안내문 
        GameObject newPref = Instantiate(errorPanel, sharePanel.transform);
        newPref.transform.SetAsLastSibling();
    }

    public void OnInputTouch()
    {
        ProjectManager.osk = System.Diagnostics.Process.Start("osk.exe");
    }

    public void CloseKeyboard()
    {
        if (ProjectManager.osk != null)
        {
            ProjectManager.osk.Kill();
            ProjectManager.osk = null;
        }
    }
}
