#include "handlingclient.h"

//(생성자)클라이언트 연결 요청을 받아야함
HandlingClient::HandlingClient()
{
    int clntAdrSz; //클라이언트 주소 크기 저장 변수
    SOCKET clntSock; //클라이언트 소켓

    serv = new ServerBase("91016"); //서버 세팅
    serv->openServer(10); //서버 소켓 오픈
    while(1)
    {
        clntSock=accept(serv->servSock,(SOCKADDR*)&clntSock,&clntAdrSz);

        //이제 들어온 클라이언트들을 구별할 수 있도록 해야하는 작업을 해보자 --클라이언트 클래스로 분리 해보고 --완료
        seperateClient(clntSock);
        //구분 완료 그럼 채팅방을 생성해야하는데 만들어둘까 아님 저들이 생성하게 할까
        //일단 read함수 쓰레드로 할당 시키기 --클라이언트 요청을 처리할것
        HANDLE thread; //스레드 핸들
        thread=(HANDLE)_beginthreadex(NULL,0,&readMSG,(void*)&clntSock,0,NULL);
    }
}
//(소멸자)클라이언트 소켓의 연결 종료
HandlingClient::~HandlingClient()
{
    for(auto mem: clntList)
    {
        closesocket(mem.clntSock); //연결된 소켓들 모두 종료
    }
}
//연결된 클라이언트 구분해 소켓 저장하기
void HandlingClient::seperateClient(SOCKET sock)
{
    char name[21];
    int len;
    len=recv(sock,name,20,0);
    name[len]=0;
    std::cout<<name<<"님이 접속하셨습니다. \n";
    
    clntInfo clnt;
    clnt.clntSock=sock;
    clnt.nick=name;
    std::cout<<"등록된 소켓 이름: "<<clnt.nick<<" 번호: "<<clnt.clntSock<<std::endl;
    clntList.push_back(clnt);
}
//각 클라이언트로부터 요청 수신 --스레드로 실행됨
unsigned WINAPI HandlingClient::readMSG(void* arg)
{
    SOCKET recvSock = *((SOCKET*)arg); //전달된 소켓 저장
}