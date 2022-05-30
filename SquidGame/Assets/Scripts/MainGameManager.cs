using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameManager : MonoBehaviour
{
    // 현재 게임 진행 상태를 저장할 열거형
    enum NowState
    {
        Select01Turn,
        Select02Turn,
        PlayerTurn,
        Result
    }
    private NowState nowState = NowState.Select01Turn;

    // 카드 인식 일시 정지
    private bool isGameOn = true;
    private bool isCharacterOn = true;

    // 현재 게임 진행 상태를 보여줄 텍스트
    public Text nowStateText;
    public Text playerHP_Text;
    public Text AIHP_Text;

    //플레이어들이 선택한 캐릭터 카드 저장할 변수
    // 4 = 오일남, 3 = 성기훈
    private int playerCharacterCard;
    private int AICharacterCard;

    // 플레이어들이 낸 카드를 저장할 변수
    // 0 = 짝, 1 = 홀
    private int playerCard;
    private int AICard;

    // 플레이어들이 이긴 라운드를 셀 변수
    private int playerHP = 5;
    private int AIHP = 5;

    // 최종 결과 창
    public GameObject Canvas_Result;
    public GameObject Canvas;

    void Start()
    {
        Canvas.SetActive(true);
        nowStateText.text = "사용자의 캐릭터 카드를 인식해주세요.";
        Canvas_Result.SetActive(false);
    }

    private void Update()
    {
        playerHP_Text.text = playerHP.ToString();
        AIHP_Text.text = AIHP.ToString();
    }

    // 캐릭터 카드가 인식 되면 값을 전달받는 메소드
    public void SelectCard(int _inputCard)
    {
        Debug.Log("not in if");
        if (isCharacterOn)
        {
            Debug.Log("in if");
            SetPlayersCard(_inputCard);
            SetMessage();
        }
    }

    // 카드가 인식 되면 값을 전달받는 메소드
    public void FilpCard(int _inputCard)
    {
        Debug.Log("not in if");
        if (isGameOn)
        {
            Debug.Log("in if");
            SetPlayersCard(_inputCard);
            SetMessage();
        }
    }

    // 해당 턴인 플레이어의 카드를 설정
    private void SetPlayersCard(int _pCard)
    {
        if (nowState == NowState.Select01Turn)
        {
            playerCharacterCard = _pCard;
            nowState = NowState.Select02Turn;
        }
        else if (nowState == NowState.Select02Turn)
        {
            AICharacterCard = _pCard;
            nowState = NowState.PlayerTurn;
        }
        else if (nowState == NowState.PlayerTurn)
        {
            playerCard = _pCard;
            AICard = Random.Range(0, 2);
            nowState = NowState.Result;
        }
    }

    // 메시지 변경
    private void SetMessage()
    {
        Debug.Log("SetMesageCalled");
        if (nowState == NowState.Select01Turn)
        {
            nowStateText.text = "사용자의 캐릭터 카드를 선택해주세요";
        }
        else if (nowState == NowState.Select02Turn)
        {
            nowStateText.text = "AI의 캐릭터 카드를 선택해주세요";
        }
        else if (nowState == NowState.PlayerTurn)
        {
            nowStateText.text = "홀/짝 카드를 선택해주세요";
        }

        else if (nowState == NowState.Result)
        {
            // 누가 승리했는지 계산하는 메소드
            CalcRoundWinner();
        }
    }

    // 승자 계산 메소드
    // 플레이어 승리 -> 1,
    // AI 승리 -> 0

    private void CalcRoundWinner()
    {
        int winner = 0;

        // 플레이어와 AI의 카드가 같은 경우
        if (playerCard == AICard)
        {
            winner = 1;
        }

        // 플레이어와 AI의 카드가 다른 경우
        else
        {
            winner = 0;
        }
        ApplyRoundWinner(winner);
    }

    // 이긴 플레이어의 메시지를 출력하고
    // 라운드 승리 횟수를 더함
    private void ApplyRoundWinner(int _winner)
    {
        if (_winner == 0)
        {
            nowStateText.text = "AI의 승리";
            playerHP--;
        }

        if (_winner == 1)
        {
            nowStateText.text = "플레이어 승리";
            AIHP--;
        }

        FindFinalWinner();
    }

    private void FindFinalWinner()
    {
        bool isGameOver = false;

        // AI 승리
        if (playerHP < 1 && AIHP > 0)
        {
            nowStateText.text = "최종 결과: AI 승리";
            isGameOver = true;
        }
        // 플레이어 최종 승리
        else if (AIHP < 1 && playerHP > 0)
        {
            nowStateText.text = "최종 결과: 플레이어 승리";
            isGameOver = true;
        }
        if (isGameOver)
        {
            isGameOn = false;
            isCharacterOn = false;
            // 최종게임 결과 화면
            Canvas.SetActive(false);
            Canvas_Result.SetActive(true);
        }
        else
        {
            if (nowState == NowState.Result)
            {
                isCharacterOn = false;
                nowState = NowState.PlayerTurn;
            }
        }
    }

    public void ResetGame()
    {
        isGameOn = true;
        isCharacterOn = true;
        nowState = NowState.Select01Turn;
        playerHP = 5;
        AIHP = 5;
        SetMessage();
        Canvas.SetActive(true);
    }
}
