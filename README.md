# SquidGame

### 팀원 및 역할
- 이지원 : 팀장 / 기획, MainScene 개발
- 이진영 : 팀원 / 기획, 자료조사, 카드제작, 스토리제작
- 박희진 : 팀원 / 기획, StartScene 개발
- 곽준석 : 팀원 / 기획, 자료조사, 카드제작, BGM

### 스토리 전개
오징어게임 참가자 ‘기훈’과 ‘일남’은 함께 
팀을 맺어 게임에 입장한다. 
팀전인줄 알았던 게임은 사실 개인전이었고 살아남기 위해선 ‘일남’과의 승부에서 승리해야 한다. 
‘기훈’과 ‘일남’은 운명을 건 마지막 승부를 벌이는데... 

### 게임 사용 카드

<div style='float: center'>
  <img src=https://user-images.githubusercontent.com/64894398/171456912-5e50ad59-ff41-4d6d-bb66-87982430861e.jpg width="300" height="300">
  <img src=https://user-images.githubusercontent.com/64894398/171457236-e69193e1-ba7c-4ca0-a9fd-974644fd26f3.png width="300" height="300">
  <img src=https://user-images.githubusercontent.com/64894398/171457294-74f92b2a-1421-4fae-ba55-d6f4cb14176e.jpg width="300" height="300">
  <img src=https://user-images.githubusercontent.com/64894398/171457301-7eeed65d-edf4-4e58-91f6-d27f6600b4bb.jpg width="300" height="300">
  <img src=https://user-images.githubusercontent.com/64894398/171457302-24ac8db4-3254-401a-98e5-46aa8d6332fd.jpg width="300" height="300">
</div>

### 게임 상세 규칙
1. 플레이어와 AI 모두 시작 점수는 5점.  
2. 플레이어는 홀 , 짝 카드만 낼 수 있다.  
3. AI는 0 혹은 1의 숫자만 낼 수 있다. 
4. AI가 내는 값이 0이면 짝, 1이면 홀이다.
5. 정답을 맞추면 상대방의 점수를 1점이 차감된다. 
6. 상대방의 점수 5점을 먼저 깎는 쪽이 승리한다.  
7. 플레이어의 값이 0이되면 GameOver. 

### 시스템 구성도
- StartScene
![image](https://user-images.githubusercontent.com/64894398/171458426-fbc1d090-18bb-4710-aa1f-859bff43b251.png)

- MainScene
![image](https://user-images.githubusercontent.com/64894398/171458518-38d7a8e4-62a8-4c16-9f31-3227739cf37d.png)

<!-- ### 해야할 일
StartScene과 MainScene으로 나눈다.

- StartScene : 스토리 형식의 이미지 파일(5개)을 보여준 후 MainScene으로 이동 (SceneManager 활용)
- MainScene : 시작 카드를 인식하면 게임이 시작, 홀/짝 카드 중 1개를 입력하면 해당 결과 값을 출력해주고 점수를 나타내 줌.
 -->
개발 기간 : 2022.05.26 ~ 2022.06.01
