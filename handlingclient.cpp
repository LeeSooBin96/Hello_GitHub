#include "handlingclient.h"

//(생성자)클라이언트 연결 요청을 받아야함
HandlingClient::HandlingClient()
{
    int clntAdrSz; //클라이언트 주소 크기 저장 변수
    SOCKET clntSock; //클라이언트 소켓
    SOCKADDR_IN clntAdr;

    serv = new ServerBase("91016"); //서버 세팅
    serv->openServer(10); //서버 소켓 오픈
    while(1)
    {
        //지금은 순차 접속만 된다. 나중에 수정하기
        clntSock=accept(serv->servSock,(SOCKADDR*)&clntAdr,&clntAdrSz);
        std::cout<<"접속한 아이피 : "<<inet_ntoa(clntAdr.sin_addr);
        //이제 들어온 클라이언트들을 구별할 수 있도록 해야하는 작업을 해보자 --클라이언트 클래스로 분리 해보고 --완료
        HANDLE hthread;
        hthread=(HANDLE)_beginthreadex(NULL,0,(_beginthreadex_proc_type)seperateClient,&clntSock,0,NULL);
        seperateClient(clntSock);
        //구분 완료 그럼 채팅방을 생성해야하는데 만들어둘까 아님 저들이 생성하게 할까
        
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
void HandlingClient::seperateClient(void* arg)
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
