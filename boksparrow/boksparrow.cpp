#include <string>

#include "clientbase.h"

int main()
{
    ClientBase clnt("10.10.20.98","91016");
    //����Ǹ� �г��� �Է� �ޱ�
    std::cout<<"�г����� �Է��ϼ���: (20�� ����)";
    std::string nick;
    std::getline(std::cin,nick);
    while(nick.size()>20)
    {
        std::cout<<"�Էµ� �г���: "<<nick; //Ȯ�ο�
        std::cout<<"�г����� �ٽ� �Է��ϼ���: (20�� ����)";
        std::getline(std::cin,nick);
    }
    //�̴г����� ������ ��������
    send(clnt.sock,nick.c_str(),nick.size(),0);
    //�������� ä�ù����� �޾ƿͼ� Ŭ���̾�Ʈ���� ���������
    

    char msg[30];
    recv(clnt.sock,msg,sizeof(msg),0); //�ӽ�
    std::cout<<msg;
    return 0;
}
