// // #include <iostream>
// // #include <cstdlib>
// // #include <cstring>
// // #include <winsock2.h>

// // #define BUF_SIZE 1024
// // void ErrorHandling(char * message);

// // int main(int argc, char *argv[])
// // {
// //     WSADATA wsaData;
// //     SOCKET hservSock, hClntSock;
// //     char message[BUF_SIZE];
// //     int strlen, i;

// //     SOCKADDR_IN servAdr, clntAdr,
// //     int clntAdrsize;

// //     if(ar)
// // }
// #include <iostream>
// #include <windows.h>
// #include <process.h>
// unsigned WINAPI ThreadFunc(void *arg);

// int main(int argc, char* argv[])
// {
//     HANDLE hThread;
//     unsigned threadID;
//     int param = 5;

//     hThread=(HANDLE)_beginthreadex(NULL,0,ThreadFunc,(void*)&param,0,&threadID);
//     if(hThread==0)
//     {
//         std::cout<<"_beginthreadex() error"<<std::endl;
//         return -1;
//     }
//     Sleep(10000);
//     puts("end of main");
//     return 0;
// }
// unsigned WINAPI ThreadFunc(void *arg)
// {
//     int i;
//     int cnt=*((int*)arg);
//     for(i=0;i<cnt;i++)
//     {
//         Sleep(1000);std::cout<<"runnign thread"<<std::endl;
//     }
//     return 0;
// }

// #pragma comment(lib, "ws2_32.lib")

// #include <iostream>
// #include <cstdlib>
// #include <cstring>
// #include <windows.h>
// #include <process.h>

// #define BUF_SIZE 100
// #define MAX_CLNT 256

// unsigned WINAPI HandleClnt(void* arg);
// void SendMSG(char * msg, int len);
// void ErrorHandling(char * msg);

// int clntCnt=0;
// SOCKET clntSocks[MAX_CLNT]; //접속한 클라이언트 소켓 저장
// HANDLE hMutex; //뮤텍스 핸들

// int main(int argc, char* argv[])
// {
//     WSADATA wsaData; //윈도우 소켓 라이브러리
//     SOCKET hServSock, hClntSock; //서버, 클라이언트 소켓 핸들
//     SOCKADDR_IN servAdr, clntAdr; //서버, 클라이언트 주소
//     int clntAdrSz; //클라이언트 주소 크기
//     HANDLE hThread; //스레드 핸들
//     if(argc!=2)
//     {
//         std::cout<<"Usage: "<<argv[0]<<" <port>\n";
//         exit(1);
//     }
//     //윈속 라이브러리 초기화
//     if(WSAStartup(MAKEWORD(2,2),&wsaData)!=0) 
//     {               //윈속 버전, WSADATA 구조체 변수의 주소값 전달
//         ErrorHandling("WSAStartup() error!");
//     }//성공시 0을, 실패시 0이 아닌 에러코드값을 반환한다.

//     hMutex=CreateMutex(NULL, FALSE, NULL);
//     hServSock=socket(PF_INET,SOCK_STREAM,0); //소켓 생성

//     //주소 정보 초기화
//     memset(&servAdr,0,sizeof(servAdr));
//     servAdr.sin_family=AF_INET; //IPv4
//     servAdr.sin_addr.s_addr=htonl(INADDR_ANY); //호스트 주소 설정
//     servAdr.sin_port=htons(atoi(argv[1])); //포트번호 설정

//     //주소 할당
//     if(bind(hServSock,(SOCKADDR*)&servAdr,sizeof(servAdr))==SOCKET_ERROR)
//     {
//         ErrorHandling("bind() error");
//     }
//     //클라이언트 연결 대기
//     if(listen(hServSock,10)==SOCKET_ERROR)
//     {           //뒤 숫자는 연결대기큐의 크기
//         ErrorHandling("listen() error");
//     }

//     while(1)
//     {
//         clntAdrSz=sizeof(clntAdr); //클라이언트 주소 크기
//         //클라이언트 연결 요청 수락
//         hClntSock=accept(hServSock,(SOCKADDR*)&clntAdr,&clntAdrSz);

//         WaitForSingleObject(hMutex,INFINITE); //임계영역 설정
//         clntSocks[clntCnt++]=hClntSock; //클라이언트 소켓 저장
//         ReleaseMutex(hMutex);

//         hThread=(HANDLE)_beginthreadex(NULL,0,HandleClnt,(void*)&hClntSock,0,NULL); //스레드 함수로 소켓 전달
//         std::cout<<"Connected client IP: "<<inet_ntoa(clntAdr.sin_addr)<<std::endl;
//     }
//     closesocket(hServSock); 
//     WSACleanup(); //윈속 라이브러리 해제
//     return 0;
// }

// unsigned WINAPI HandleClnt(void* arg) //스레드에서 실행되는 함수 //run()
// {
//     SOCKET hClntSock=*((SOCKET*)arg); //전달된 소켓 저장
//     int strLen=0, i;
//     char msg[BUF_SIZE];

//     while((strLen=recv(hClntSock,msg,sizeof(msg),0))!=0) //메시지 수신
//     {
//         // SendMSG(msg,strLen); //메시지 전송
//         int i;
//         WaitForSingleObject(hMutex,INFINITE);
//         for(i=0;i<clntCnt;i++) //접속한 클라이언트 들에게
//         {
//             if(hClntSock != clntSocks[i])
//                 send(clntSocks[i],msg,strLen,0); //메시지 전송
//         }
//         ReleaseMutex(hMutex);
//     }
//     //메시지길이가 0이면 클라이언트 소켓 연결 종료
//     WaitForSingleObject(hMutex,INFINITE); //임계영역 설정
//     for(i=0;i<clntCnt;i++) //이 시점의 접속한 클라이언트 수만큼
//     {
//         if(hClntSock == clntSocks[i]) //메시지 보낸 소켓(클라이언트) 찾기
//         {
//             while(i++<clntCnt-1) //클라이언트 소켓 배열의 마지막으로
//             {
//                 clntSocks[i]=clntSocks[i+1]; 
//                 break;
//             }
//         }
//     }
//     clntCnt--; //접속한 클라이언트 수에서 제외
//     ReleaseMutex(hMutex);
//     closesocket(hClntSock); //소켓 연결 종료
//     return 0;
// }
// void SendMSG(char* msg, int len)
// {
//     int i;
//     WaitForSingleObject(hMutex,INFINITE);
//     for(i=0;i<clntCnt;i++) //접속한 클라이언트 들에게
//     {
//         send(clntSocks[i],msg,len,0); //메시지 전송
//     }
//     ReleaseMutex(hMutex);
// }
// void ErrorHandling(char* msg)
// {
//     fputs(msg,stderr);
//     fputc('\n',stderr);
//     exit(1);
// }
// #include <iostream>
// int main()
// {
//     std::cout<<"hello world"<<std::endl;
// }
// #include <iostream>
// #include <winsock2.h>
// #include <thread>

// using namespace std;

// #define PACKET_SIZE 1024
// SOCKET skt,client_sock;

// void proc_recvs(){
//     char buffer[PACKET_SIZE]={0};
//     while(!WSAGetLastError())
//     {
//         ZeroMemory(&buffer,PACKET_SIZE);
//         recv(client_sock,buffer,PACKET_SIZE,0);
//         cout<<"받은 메시지: "<<buffer<<endl;
//     }
// }

// int main(){
// WSADATA wsa;
// WSAStartup(MAKEWORD(2,2), &wsa);

// skt = socket(PF_INET,SOCK_STREAM,IPPROTO_TCP);

// SOCKADDR_IN addr = {};
// addr.sin_family = AF_INET;
// addr.sin_port = htons(4444);
// addr.sin_addr.s_addr = htonl(INADDR_ANY);

// bind(skt, (SOCKADDR*)&addr,sizeof(addr));
// listen(skt,SOMAXCONN);

// SOCKADDR_IN client = {};
// int client_size = sizeof(client);
// ZeroMemory(&client,client_size); //0으로 초기화
// client_sock = accept(skt,(SOCKADDR*)&client,&client_size);

// char buffer[PACKET_SIZE]={0};
// thread proc2(proc_recvs);

// while(!WSAGetLastError())
// {
//     cin>>buffer;
//     send(client_sock,buffer,strlen(buffer),0);
// }

// proc2.join(); //스레드 종료를 기다림
// closesocket(client_sock);
// closesocket(skt);
// WSACleanup();
// }
// 출처: https://mawile.tistory.com/24 [전생했더니 C딱인생이였던건에 대하여∑:티스토리]
#include <iostream>
#include <vector>
int main()
{
    std::vector<int*> test;
    int* iptr= new int(1);
    test.push_back(iptr);
    iptr=new int(2);
    test.push_back(iptr);
    iptr=new int(3);
    test.push_back(iptr);
    for(int* m: test)
    {
        std::cout<<*m<<std::endl;
    }
    iptr=new int(2);
    for(int i=0;i<test.size();i++)
    {
        if(*iptr==*test[i])
        {
            delete test[i];
            while(i<test.size()-1)
            {
                test[i]=test[i+1];
                i++;
            }
        }
    }
    test.pop_back();
    for(int* m: test)
    {
        std::cout<<*m<<std::endl;
    }
    return 0;
}