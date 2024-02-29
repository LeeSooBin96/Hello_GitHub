#ifndef _HANDLING_CLIENT_H
#define _HANDLING_CLIENT_H

#include <process.h>
#include <vector>

#include "serverbase.h"

struct clntInfo
{
    std::string nick;
    SOCKET clntSock;
};
//클라이언트를 다루기 위한 클래스
class HandlingClient
{
    ServerBase* serv; //서버 기본 셋팅 클래스
    std::vector<clntInfo> clntList; //닉네임-소켓 연결 구조체 배열

public:
    HandlingClient(); //(생성자)클라이언트 연결 요청을 받아야함
    ~HandlingClient(); //(소멸자)클라이언트 소켓의 연결 종료

    void seperateClient(void* arg); //연결된 클라이언트 구분해 소켓 저장하기

};
#endif