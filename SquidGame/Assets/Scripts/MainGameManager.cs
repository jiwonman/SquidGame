using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameManager : MonoBehaviour
{
    // 현재 게임 진행 상태를 저장할 열거형
    // 열거형은 변수처럼 사용하지 못한다.
    enum NowState
    {
        PlayerCardTurn, // 0
        PlayerTurn,     // 1
        AITurn,         // 2
        Result          // 3
    }
    private NowState nowState = 0;

    // 카드 인식 일시 정지
    private bool isGameOn = true;
    private bool isCharacterOn = true;

    // 현재 게임 진행 상태를 보여줄 텍스트
    public Text nowStateText;
    public Text playerHP_Text;
    public Text AIHP_Text;
    public Text Current_Text;

    //플레이어들이 선택한 캐릭터 카드 저장할 변수
    // 오일남, 성기훈
    private string playerCharacterCard;
    private string AICharacterCard;

    // 플레이어들이 낸 카드를 저장할 변수
    // 0 = 짝, 1 = 홀, 2 = AI 인식
    private int playerCard;
    private int AICard;
    private int testCard;

    // 플레이어들이 이긴 라운드를 셀 변수
    private int playerHP = 5;
    private int AIHP = 5;

    // 최종 결과 창
    public GameObject Canvas_Result;
    public GameObject Canvas;

    void Start()
    {
        Canvas.SetActive(true);
        // Current_Text.text = nowState.ToString();
        nowStateText.text = "사용자 캐릭터 카드 선택";
        Canvas_Result.SetActive(false);
    }

    private void Update()
    {
        playerHP_Text.text = playerHP.ToString();
        AIHP_Text.text = AIHP.ToString();
    }

    // 캐릭터 카드가 인식 되면 값을 전달받는 메소드
    public void SelectCard(string _inputPlayerCard)
    {
        // Character Card를 받으면 False, 받지 못하면 True
        if (isCharacterOn)
        {
            Debug.Log("in");
            SetPlayersCard(_inputPlayerCard);
            SetMessage();
        }
        Debug.Log("Loop Out");
    }

    private void SetPlayersCard(string _p1Card)
    {
        // 캐릭터 카드 선택 상태
        if ((int)nowState == 0)
        {
            if (_p1Card == "성기훈")
            {
                playerCharacterCard = _p1Card;
                AICharacterCard = "오일남";
            }
            else if (_p1Card == "오일남")
            {
                playerCharacterCard = _p1Card;
                AICharacterCard = "성기훈";
            }
            nowState++;
            Current_Text.text = "AI : " + AICharacterCard;
        }
    }

    // 카드가 인식 되면 값을 전달받는 메소드
    public void FilpCard(int _inputCard)
    {
        // Game이 끝나지 않으면 지속적으로 홀, 짝, 인식카드를 받는다.
        if (isGameOn)
        {
            Debug.Log("in if");
            SetEvenCard(_inputCard);
            SetMessage();
        }
        Debug.Log("Loop Out");
    }

    // 해당 턴인 플레이어의 카드를 설정
    private void SetEvenCard(int _pCard)
    {
        if ((int)nowState == 1)
        {
            // nowState ==1 에 AI 인식 카드가 들어왔을 때
            if (_pCard == 2)
            {
                Debug.Log("Loop Out");
                // 빠져나와서 다음 인식을 기다림
            }
            else
            {
                // 아닐 경우 인식된 카드를 playerCard로 저장하고 AICard에 0,1 중 랜덤 값을 넣어줌
                playerCard = _pCard;
                AICard = Random.Range(0, 2);
                if (AICard == 0)
                {
                    Current_Text.text = "AI의 카드 짝";
                    nowState++;
                }
                else if (AICard == 1)
                {
                    Current_Text.text = "AI의 카드 홀";
                    nowState++;
                }
            }


        }
        else if ((int)nowState == 2)
        {
            // 인식용 AI Card : AI Turn만 인식해주고 다음 상태로 넘어감.
            testCard = _pCard;
            nowState++;
        }
        else
        {
            // nowState 상태 표시 하고 Loop Out, log 확인을 위함
            Current_Text.text = _pCard.ToString();
            Debug.Log("Loop Out");
        }
    }

    // 메시지 변경
    private void SetMessage()
    {
        Debug.Log("Message");
        if ((int)nowState == 0)
        {
            nowStateText.text = "사용자 캐릭터 카드 선택";
        }
        else if ((int)nowState == 1)
        {
            nowStateText.text = "홀/짝 카드 선택";
        }
        else if ((int)nowState == 2)
        {
            nowStateText.text = "AI Turn";
            if (AICard == 0)
            {
                Current_Text.text = "AI의 카드 짝";
            }
            else if (AICard == 1)
            {
                Current_Text.text = "AI의 카드 홀";
            }
        }
        else if ((int)nowState == 3)
        {
            WhoIsWinner();
        }
    }

    // 승자 계산 메소드
    // 플레이어 승리 : 1,
    // AI 승리 : 0

    private void WhoIsWinner()
    {
        int winner = 0;

        // 플레이어와 AI의 카드가 같은 경우
        if (playerCard == 0 && AICard == 0)
        {
            winner = 1;
        }

        // 플레이어와 AI의 카드가 다른 경우
        else if (playerCard == 0 && AICard == 1)
        {
            winner = 0;
        }
        else if (playerCard == 1 && AICard == 0)
        {
            winner = 0;
        }
        else if (playerCard == 1 && AICard == 1)
        {
            winner = 1;
        }

        //승리 메시지 보내기
        HpAttack(winner);
    }

    // 이긴 플레이어의 메시지를 출력하고 진 사람의 HP 깎기
    private void HpAttack(int _winner)
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

        // 라운드마다 Result 확인 메서드
        ResultTo();
    }

    private void ResultTo()
    {
        bool isGameOver = false;

        // AI 최종 승리 GameOver
        if ((playerHP == 0) && (AIHP > 1))
        {
            nowStateText.text = "최종 결과: AI 승리";
            isGameOver = true;
        }
        // 플레이어 최종 승리 GameOver
        else if ((AIHP == 0) && (playerHP > 1))
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
            // 최종 승부가 나지않으면 상태값 변경

            Current_Text.text = "";
            isCharacterOn = false;
            testCard = 0;
            nowState = 0;
            nowState++;
        }
    }

    public void ResetGame()
    {
        isGameOn = true;
        isCharacterOn = true;
        nowState = 0;
        playerHP = 5;
        AIHP = 5;
        SetMessage();
        Canvas.SetActive(true);
        Current_Text.text = "";
    }
}
