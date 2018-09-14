using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour {

    public static StartMenuController Instance;

    public static string AccountName = "";
    public static string ServerName = "";
    public static string selectedCharacterName = "";
    public static string selectedCharacterLevel = "";

    public GameObject loginGo;
    public GameObject startGo;
    public GameObject registerGo;
    public GameObject serverGo;
    public GameObject characterSelectGo;
    public GameObject characterCreateGo;

    //login
    public InputField account_Login;
    public InputField password_Login;
    public Button loginBtn_Login;
    public Button registerBtn_Login;
    public GameObject prompt_Login;

    //register
    public InputField account_Register;
    public InputField password_Register;
    public InputField repassword_Register;
    public Button cancelBtn_Register;
    public Button confirmBtn_Register;
    public GameObject prompt_Register;

    //start
    public Button accountChooseBtn_Start;
    public Button serverChooseBtn_Start;
    public Button startGame_Start;

    //server
    public Button selectServerRed;
    public Button selectServerGreen;

    //character
    public Text characterName;
    public Text characterLevel;
    public Text noticeContent;
    public Button createCharacterBtn;
    public Button deleteCharacterBtn;
    public Button enterGameBtn;
    public InputField inputCharacterName;
    public Button characterConfirm;
    private bool hasSelectedCharacter;
    private int selectCharacterIndex;

   
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        loginGo.SetActive(true);
        startGo.SetActive(false);
        registerGo.SetActive(false);
        serverGo.SetActive(false);
        prompt_Login.SetActive(false);
        prompt_Register.SetActive(false);
        characterSelectGo.SetActive(false);
        characterCreateGo.SetActive(false);

        //login
        loginBtn_Login.onClick.AddListener(OnClickLogin);
        registerBtn_Login.onClick.AddListener(OnClickRegister);
        //register
        cancelBtn_Register.onClick.AddListener(OnClickCancel);
        confirmBtn_Register.onClick.AddListener(OnClickConfirm);
        //start
        accountChooseBtn_Start.onClick.AddListener(() => { startGo.SetActive(false); loginGo.SetActive(true); });
        serverChooseBtn_Start.onClick.AddListener(() => { startGo.SetActive(false); serverGo.SetActive(true); });
        startGame_Start.onClick.AddListener(OnClikStartGame);

        //server
        selectServerRed.onClick.AddListener(OnClickSelectedServerRed);
        selectServerGreen.onClick.AddListener(OnClickSelectedServerGreen);

        //character
        hasSelectedCharacter = false;
        characterConfirm.onClick.AddListener(OnClickCharacterConfirm);
        createCharacterBtn.onClick.AddListener(() => { characterSelectGo.SetActive(false); characterCreateGo.SetActive(true); });
        deleteCharacterBtn.onClick.AddListener(OnClickDeleteCharacter);
        enterGameBtn.onClick.AddListener(EnterGame);
    }

    
    #region Login
    private void OnClickLogin()
    {
        //1.验证账号和密码
        string tempAccount = account_Login.text.Trim();
        string tempPassword = password_Login.text.Trim();

        //2.验证不通过，提示“账号或密码有误，请重新输入”

        //3.验证通过
        AccountName = tempAccount;
        loginGo.SetActive(false);
        startGo.SetActive(true);
        UpdateStartInfo();
    }

    private void OnClickRegister()
    {
        loginGo.SetActive(false);
        registerGo.SetActive(true);
    }
    #endregion

    #region Register
    private void OnClickCancel()
    {
        loginGo.SetActive(true);
        registerGo.SetActive(false);
    }

    private void OnClickConfirm()
    {
        //1. 核对密码是否一致
        if (password_Register.text != repassword_Register.text)
        {
            prompt_Register.SetActive(true);
            prompt_Register.GetComponentInChildren<Text>().text = "密码不一致";
            password_Register.text = "";
            repassword_Register.text = "";
            return;
        }

        //2. 验证账号是否重复

        //3. 验证通过
        AccountName = account_Register.text.Trim();
        registerGo.SetActive(false);
        startGo.SetActive(true);
        UpdateStartInfo();
    }
    #endregion

    #region Start
    private void OnClikStartGame()
    {
        characterSelectGo.SetActive(true);
        startGo.SetActive(false);
        InitCharacterInfo();
    }

    private void UpdateStartInfo()
    {
        accountChooseBtn_Start.gameObject.GetComponentInChildren<Text>().text = AccountName;
        serverChooseBtn_Start.gameObject.GetComponentInChildren<Text>().text = ServerName;
    }

    #endregion

    #region server    
    private void OnClickSelectedServerRed()
    {
        ServerProperty sp = selectServerRed.gameObject.GetComponent<ServerProperty>();
        SelectServer(sp);
    }

    private void OnClickSelectedServerGreen()
    {
        ServerProperty sp = selectServerGreen.gameObject.GetComponent<ServerProperty>();
        SelectServer(sp);
    }

    private void SelectServer(ServerProperty sp)
    {
        ServerName = sp.serverName;
        serverGo.SetActive(false);
        startGo.SetActive(true);
        UpdateStartInfo();
    }
    #endregion

    #region character
    public void SelectCharacter(string character)
    {
        selectedCharacterName = character;
        hasSelectedCharacter = true;
        if (character == "man")
        {
            GameObject.Find("Canvas/CharacterCreate/ShowCharacterParent/ShowMan").transform.localScale = Vector3.one * 1.5f;
            GameObject.Find("Canvas/CharacterCreate/ShowCharacterParent/ShowGirl").transform.localScale = Vector3.one;
            selectCharacterIndex = 0;
        }
        else if (character == "girl")
        {
            GameObject.Find("Canvas/CharacterCreate/ShowCharacterParent/ShowMan").transform.localScale = Vector3.one;
            GameObject.Find("Canvas/CharacterCreate/ShowCharacterParent/ShowGirl").transform.localScale = Vector3.one * 1.5f;
            selectCharacterIndex = 1;
        }

    }

    private void OnClickCharacterConfirm()
    {
        selectedCharacterName = inputCharacterName.text.Trim();
        if (selectedCharacterName == "")
            return;
        selectedCharacterLevel = "Lv.1";        
        GameObject.Find("Canvas/CharacterCreate/ShowCharacterParent/ShowMan").transform.localScale = Vector3.one;
        GameObject.Find("Canvas/CharacterCreate/ShowCharacterParent/ShowGirl").transform.localScale = Vector3.one;
        characterCreateGo.SetActive(false);
        characterSelectGo.SetActive(true);
        InitCharacterInfo();
    }

    private void OnClickDeleteCharacter()
    {
        //TODO  删除服务器上角色

        //处理客户端显示
        hasSelectedCharacter = false;
        selectedCharacterName = "";
        selectedCharacterLevel = "";
        InitCharacterInfo();
    }

    private void InitCharacterInfo()
    {
        //从服务器读取角色信息
        //bool hasSelectedCharacter = LoadCharacterFromServer()

        if (hasSelectedCharacter)
        {
            characterName.text = selectedCharacterName;
            characterLevel.text = selectedCharacterLevel;
            GameObject goCharacterParent = GameObject.Find("Canvas/CharacterSelect/CharacterParent");
            for (int i = 0; i < goCharacterParent.transform.childCount; i++)
            {
                GameObject go = goCharacterParent.transform.GetChild(i).gameObject;
                if (i == selectCharacterIndex)
                {
                    go.SetActive(true);
                }
                else
                {
                    go.SetActive(false);
                }
            }

            //限制只能创建一个角色
            createCharacterBtn.gameObject.SetActive(false);
            deleteCharacterBtn.gameObject.SetActive(true);
        }
        else
        {
            characterName.text ="";
            characterLevel.text = "";
            GameObject goCharacterParent = GameObject.Find("Canvas/CharacterSelect/CharacterParent");
            for (int i = 0; i < goCharacterParent.transform.childCount; i++)
            {
                goCharacterParent.transform.GetChild(i).gameObject.SetActive(false);               
            }

            createCharacterBtn.gameObject.SetActive(true);
            deleteCharacterBtn.gameObject.SetActive(false);            
        }
    }

    private void EnterGame()
    {
        //TODO
        if (hasSelectedCharacter)
        {
            //Enetr Game
            Debug.Log("enter game");
        }
    }
    #endregion

}
