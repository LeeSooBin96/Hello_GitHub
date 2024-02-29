//namespace Hello
//{
//    internal class MainApp
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello, World!");
//        }
//    }
//}
//using System; //이것만하면 Console.WriteLine() 이렇게 써야하고
//using static System.Console; //이렇게 하면 그냥 WriteLine만!

//namespace Hello //모든 소스파일에 하나씩 존재 --여러개 존재도 가능함! 하지만 보통 하나
//{
//    class MainApp
//    {
//        //프로그램이 실행이 시작되는 곳
//        static void Main(string[] args) //프로그램의 진입점
//        {
//            if (args.Length == 0)
//            {
//                Console.WriteLine("사용법: Hello.exe <이름>");
//                return;
//            }
//            WriteLine("Hello, {0}!", args[0]);
//        }
//    }
//}
//연습문제 1.
//using static System.Console;

//namespace Exercise1
//{
//    class MainApp
//    {
//        static void Main()
//        {
//            Write("여러분, "); //개행이 되지 않음 C++ : std::cout<<"여러분, ";
//            WriteLine("안녕하세요? "); //개행이 자동으로 됨 C++ : std::cout<<"안녕하세요? "<<std::endl;
//            Write("반"); //큰따옴표 언달아 문자열 출력하는것도 허용은 안됨. printf 때 처럼 포매팅은 가능
//            Write("{0}{1}","갑","습니다!" ); //포매팅 형식! 출력문 둘다 가능 
//        }
//    }
//}
//연습문제 2.
//using System; //문제에서 요구한듯한 Using 선언 모양
//namespace Exercise2
//{
//    class MainApp //메인을 실행하는 모양에 익숙해져야할 것 같다.
//    {
//        static void Main(string[] args) //static 제한자에 의해 프로그램 실행과 동시에 메모리에 적재되고 실행되는 방식인가
//        {
//            Console.WriteLine("Hello World!"); //문제에서 .WriteLine 앞의 글자를 물었다.
//        }
//    }
//}
////정수 형식 예제 프로그램
//using System;

//namespace integralTypes
//{
//    class MainAPP
//    {
//        static void Main(string[] args)
//        {
//            sbyte a = -128; //최소 숫자
//            a -= 1; //127 --담을 수 있는 크기의 한계 확인 가능!
//            byte b = 128; //sbyte : -128~127, byte:0~255

//            Console.WriteLine($"a={a}, b={b}"); //변수 바로 넣는 포매팅! --파이썬에서 했던 것 다들 되는듯

//            short c = -30000;//short : -32,768~32,767
//            ushort d = 60000;//ushort : 0~65,535

//            Console.WriteLine($"c={c}, d={d}");

//            int e = -10000_0000; //_는 자리 구분자!
//            uint f = 3_0000_0000; //int : -21억..~21억... , 그러면 uint는 0~21억*2...!

//            Console.WriteLine($"e={e}, f={f}");

//            long g = -5000_0000_0000; //long은 2^62! 그냥 크다.. 
//            ulong h = 200_0000_0000_0000; //각 크기에 맞게 적절히 메모리낭비 없이 사용하기

//            Console.WriteLine($"g={g}, h={h}");
//        }
//    }
//}
////2진수, 10진수, 16진수 리터럴
//using System;

//namespace IntegerLiterals
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            byte a = 240; //10진수 리터럴
//            Console.WriteLine($"a={a}");

//            byte b = 0b1111_0000; //2진수 리터럴 --자리수
//            Console.WriteLine($"b={b}");

//            byte c = 0xF0; //16진수 리터럴
//            Console.WriteLine($"c={c}");

//            uint d = 0x1234_abcd; //16진수 리터럴
//            Console.WriteLine($"d={d}");
//        }
//    }
//}
////부호화 절댓값과 2의보수법
//using System;

//namespace SignedUnsigned
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            byte a = 255;//부호화 절댓값 방식에서 1111(2) = 255(10)
//            byte c = 0b1111_1111;
//            sbyte b = (sbyte)a; //2의 보수법에서는 1111(2) = -1(10)
//            sbyte d = (sbyte)c;

//            Console.WriteLine(a);
//            Console.WriteLine(b);
//            Console.WriteLine(c);
//            Console.WriteLine(d);
//        }
//    }
//}
////오버플로우
//using System;

//namespace Overflow
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            uint a = uint.MaxValue; //42억 어쩌고저쩌고

//            Console.WriteLine(a);

//            a = a + 1; //범위 벗어남! --오버플로우 => 최저값으로 돌아간다.

//            Console.WriteLine(a);
//        }
//    }
//}
////부동 소수점 형식
//using System;

//namespace FloatingPoint
//{
//    class MainAPP
//    {
//        static void Main(string[] args)
//        {
//            float a = 3.1415_9265_3589_7932_3846f; ///float 형식 변수에 값을 직접 할당하려면 숫자 뒤에 f
//            Console.WriteLine(a); //4바이트까지만 저장하고 나머지는 버림 = 3.1415927

//            double b = 3.1415_9265_3589_7932_3846;
//            Console.WriteLine(b); //8바이트까지만 저장하고 나머지는 버림 3.141592653589793
//        }
//    }
//}
////decimal
//using System;

//namespace Decimal
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            float a = 3.1415_9265_3589_7932_3846_2643_3832_79f; //float형식
//            double b = 3.1415_9265_3589_7932_3846_2643_3832_79; //double형식
//            decimal c = 3.1415_9265_3589_7932_3846_2643_3832_79m; //decimal형식 (뒤에 m!)

//            Console.WriteLine(a);
//            Console.WriteLine(b);
//            Console.WriteLine(c);
//        }
//    }
//}
////char형 변수
//using System;

//namespace Char
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            char a = '안'; //이전의 1바이트 char형 변수에는
//            char b = '녕'; //이렇게 한글 한문자를 넣지는 못하였지만
//            char c = '하'; //유니코드 문자를 지원하기에
//            char d = '세'; //2바이트 크기를 담을 수 있어
//            char e = '요'; //char형에 한글 저장 가능!

//            Console.Write(a);
//            Console.Write(b);
//            Console.Write(c);
//            Console.Write(d);
//            Console.Write(e);
//            Console.WriteLine(); //writeLine에 매개변수를 전달하지 않으면 그저 줄바꿈 실행
//        }
//    }
//}
////string형 변수
//using System;

//namespace String
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            string a = "안녕하세요?"; //string형은 큰따옴표!
//            string b = "몽스입니다.";

//            Console.WriteLine(a);
//            Console.WriteLine(b);
//        }
//    }
//}
////"""여러줄"""
//using System;

//namespace Multiline
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            string multiline = """
//                별 하나에 추억과
//                별 하나에 사랑과
//                별 하나에 쓸쓸함과
//                별 하나에 동경과
//                별 하나에 시와
//                별 하나에 어머니, 어머니
//                """;
//            //이렇게 여러줄을 한번에 문자열로 묶어서 대입할 수 있다.
//            Console.WriteLine(multiline);
//        }
//    }
//}
////bool형 변수
//using System;

//namespace MainApp
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            bool a = true; //각각 
//            bool b = false; //1바이트씩 차지

//            Console.WriteLine(a); 
//            Console.WriteLine(b);

//        }
//    }
//}
//// object형 변수
//using System;

//namespace Object
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            object a = 123; //정수형
//            object b = 3.1415926535897932846264383279m; //decimal형
//            object c = true; //bool형
//            object d = "안녕하세요."; //string형

//            Console.WriteLine(a);
//            Console.WriteLine(b);
//            Console.WriteLine(c);
//            Console.WriteLine(d);

//        }
//    }
//}
////박싱과 언박싱의 의미
//using System;

//namespace BoxingUnboxing
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            int a = 123;
//            object b = (object)a; //a에 담긴 값을 박싱해서 힙에 저장 --즉, a의 값 123을 b에 할당함!
//            int c = (int)b; //b에 담긴 값을 언박싱해서 스택에 저장 --즉, b에 할당된 값 123을 꺼내서 c에 대입!

//            Console.WriteLine(a);
//            Console.WriteLine(b);
//            Console.WriteLine(c);

//            double x = 3.1414213;
//            object y = x; //x에 담긴 값을 박싱해서 힙에 저장 --즉, x의 값 3.1414213을 y에 할당
//            double z = (double)y; //y에 담긴 값을 언박싱해서 스택에 저장 --즉, y에 할당된 값 3.1414213을 꺼내서 z에 대입

//            Console.WriteLine(x);
//            Console.WriteLine(y);
//            Console.WriteLine(z);

//        }
//    }
//}
////크기가 서로 다른 정수 형식 사이의 변환
//using System;

//namespace IntegralConversion
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            sbyte a = 127;
//            Console.WriteLine(a);

//            int b = (int)a; //언박싱
//            Console.WriteLine(b);

//            int x = 128; // sbyte의 최대값 127보다 1 큰 수
//            Console.WriteLine(x);

//            sbyte y = (sbyte)x; //언박싱 --오버플로우(int 4Byte, sbyte 1Byte)
//            Console.WriteLine(y);
//        }
//    }
//}
 
