// #include <iostream>
// #include <cstdlib>
// #include <cstring>
// #include <string>
// #include <windows.h>
// #include <process.h>

// #define BUF_SIZE 100
// #define NAME_SIZE 20

// unsigned WINAPI SendMSG(void * arg);
// unsigned WINAPI RecvMSG(void * arg);
// void ErrorHandling(char* msg);

// char name[NAME_SIZE]="[DEFAULT]";
// char msg[BUF_SIZE];

// int main(int argc, char* argv[])
// {
//     WSADATA wsaData; //윈속 라이브러리
//     SOCKET hSock; //소켓
//     SOCKADDR_IN servAdr; //소켓 주소 정보
//     HANDLE hSndThread, hRcvThread; //쓰레드 핸들
//     if(argc!=4)
//     {
//         std::cout<<"Usage : "<<argv[0]<<" <IP> <port> <name>\n";
//         exit(1);
//     }
//     //윈속 라이브러리 초기화
//     if(WSAStartup(MAKEWORD(2,2),&wsaData)!=0)
//     {
//         ErrorHandling("WSAStartup() error!");
//     }

//     sprintf(name,"[%s]",argv[3]); //입력된 이름으로 설정
//     hSock=socket(PF_INET,SOCK_STREAM,0); //소켓 생성
//     //주소 정보 초기화
//     memset(&servAdr,0,sizeof(servAdr));
//     servAdr.sin_family=AF_INET;
//     servAdr.sin_addr.s_addr=inet_addr(argv[1]); //입력된 아이피
//     servAdr.sin_port=htons(atoi(argv[2])); //입력된 포트번호
//     //서버에 연결
//     if(connect(hSock,(SOCKADDR*)&servAdr,sizeof(servAdr))==SOCKET_ERROR)
//     {
//         ErrorHandling("coonect() error");
//     }
//     //메시지 송신 스레드 연결
//     hSndThread=(HANDLE)_beginthreadex(NULL,0,SendMSG,(void*)&hSock,0,NULL);
//     //메시지 수신 스레드 연결
//     hRcvThread=(HANDLE)_beginthreadex(NULL,0,RecvMSG,(void*)&hSock,0,NULL);

//     //스레드 함수 반환되면 자동 소멸 (옵션은 바꿀 수 있음)
//     WaitForSingleObject(hSndThread,INFINITE);
//     WaitForSingleObject(hRcvThread,INFINITE);
//     closesocket(hSock);
//     WSACleanup();
//     return 0;
// }
// unsigned WINAPI SendMSG(void * arg) //send thread main
// {
//     SOCKET hSock=*((SOCKET*)arg); //소켓 저장
//     char nameMSG[NAME_SIZE+BUF_SIZE];
//     while(1)
//     {
//         fgets(msg,BUF_SIZE,stdin); //메시지 입력
//         if(!strcmp(msg,"q\n")||!strcmp(msg,"Q\n")) //q나 Q면 종료
//         {
//             closesocket(hSock);
//             exit(0);
//         }
//         sprintf(nameMSG,"%s %s",name,msg); 
//         send(hSock,nameMSG,strlen(nameMSG),0); //메시지 서버에 전송
//     }
//     return 0;
// }
// unsigned WINAPI RecvMSG(void* arg)
// {
//     int hSock=*((SOCKET*)arg);
//     char nameMSG[NAME_SIZE+BUF_SIZE];
//     int strLen;
//     while(1)
//     {
//         strLen=recv(hSock,nameMSG,NAME_SIZE+BUF_SIZE-1,0); //베시지 수신 및 수신받은 메시지 길이 저장
//         if(strLen==-1) return -1;
//         nameMSG[strLen]=0; //문자열 끝 지정
//         fputs(nameMSG,stdout); //수신된 메시지 출력
//     }
//     return 0;
// }
// void ErrorHandling(char* msg)
// {
//     fputs(msg,stderr);
//     fputc('\n',stderr);
//     exit(1);
// }
#include <iostream>
#include <winsock2.h>
using namespace std;

#define PACKET_SIZE 1024

SOCKET skt;

int main(){
	WSADATA wsa;
	WSAStartup(MAKEWORD(2,2),&wsa);

	skt = socket(PF_INET,SOCK_STREAM,IPPROTO_TCP);

	SOCKADDR_IN addr = {};
	addr.sin_family = AF_INET;
	addr.sin_port = htons(4444);
	addr.sin_addr.s_addr = inet_addr("127.0.0.1");
	
	while(1){
		if(!connect(skt, (SOCKADDR*)&addr,sizeof(addr))) break;
	}
    
	closesocket(skt);
	WSACleanup();
}
// 출처: https://mawile.tistory.com/24 [전생했더니 C딱인생이였던건에 대하여∑:티스토리]