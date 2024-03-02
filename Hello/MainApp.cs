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
//부호 있는 정수 형식과 부호 없는 정수 형식 사이의 변환
//using System;

//namespace SignedUnsignedConversion
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            int a = 500;
//            Console.WriteLine(a);

//            uint b = (uint)a;
//            Console.WriteLine(b);

//            int x = -30;
//            Console.WriteLine(x);

//            uint y = (uint)x; //부호 없는 애한테 음수를 주면
//            Console.WriteLine(y); //당연히 문제가 생기겠죠?
//            Console.WriteLine(uint.MaxValue);
//        }
//    }
//}
////부동 소수점 형식과 정수 형식 사이의 변환
//using System;

//namespace FloatToIntegral
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            float a = 0.9f;
//            int b = (int)a; //기수부분 모두 잘려버림 0만 저장
//            Console.WriteLine(b);

//            float c = 1.1f;
//            int d = (int)c; //마찬가지 소수점아래 다 빼고 1만 저장
//            Console.WriteLine(d);
//        }
//    }
//}
////문자열을 숫자로, 숫자를 문자열로
//using System;

//namespace StringNumberConversion
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            int a = 123;
//            string b = a.ToString(); //슷자 -> 문자열로 바꿔주는 메소드 ToString!
//            Console.WriteLine(a+1); //+1을 하면 숫자는 값이 증가
//            Console.WriteLine(b+1); //+1을 하면 문자열에 추가되는 것(문자열과 숫자를 함께 출력할 수 있음을 확인)

//            float c = 3.14f;
//            string d = c.ToString(); //부동소수점형도 가능
//            Console.WriteLine(d); //ToString은 object 로부터 상속받은 메소드를 재정의 한것(오버라이드)

//            string e = "123456";
//            int f = Convert.ToInt32(e); //Parse도 가능!
//            int i = int.Parse(e); //이렇게! C#의 정수 계열, 보동소수점형 데이터형에서 제공하는 메소드
//            Console.WriteLine(f);
//            Console.WriteLine(i+1); //수를 더해보면 잘 변환된것을 확인할 수 있다

//            string g = "1.2345";
//            float h = float.Parse(g);
//            Console.WriteLine(h);
//        }
//    }
//}
////상수
//using System;

//namespace Constant
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            const int MAX_INT = 2147483647; //상수의 선언 --초기화 필수
//            const int MIN_INT = -2147483648; //절대 값을 변경할 수 없음

//            Console.WriteLine(MAX_INT);
//            Console.WriteLine(MIN_INT);
//        }
//    }
//}
////열거형
//using System;

//namespace Enum
//{
//    class MainApp
//    {
//        enum DialogResult { YES, NO, CANCEL, CONFIRM, OK }; //대화에 대한 응답을 열거형 상수로 선언

//        static void Main(string[] args)
//        {
//            Console.WriteLine((int)DialogResult.YES); //값을 주지 않았기에 자동으로 0부터 시작
//            Console.WriteLine(DialogResult.YES); //출력시 형변환 안해주면 YES(상수명)로 출력된다.
//            Console.WriteLine((int)DialogResult.NO);
//            Console.WriteLine((int)DialogResult.CANCEL);
//            Console.WriteLine((int)DialogResult.CONFIRM);
//            Console.WriteLine((int)DialogResult.OK);
//        }
//    }
//}
////열거형 변수
//using System;
//namespace Enum2
//{
//    class MainApp
//    {
//        enum DialogResult {YES, NO, CANCEL, CONFIRM, OK};

//        static void Main(string[] args)
//        {
//            DialogResult result = DialogResult.YES; //열거형 변수에는 이렇게 열거형 상수만 대입할 수 있다

//            Console.WriteLine(result == DialogResult.YES);
//            Console.WriteLine(result == DialogResult.NO);
//            Console.WriteLine(result == DialogResult.CANCEL);
//            Console.WriteLine(result == DialogResult.CONFIRM);
//            Console.WriteLine(result == DialogResult.OK);
//        }
//    }
//}
////열거형 상수에 값 할당
//using System;

//namespace Enum3
//{
//    class MainApp
//    {
//        enum DialogResult {YES=10,NO,CANCEL,CONFIRM=50,OK} //세미콜론 없어도 됨

//        static void Main(string[] args)
//        {
//            Console.WriteLine((int)DialogResult.YES); //10
//            Console.WriteLine((int)DialogResult.NO); //11 --이렇게 할당 안된 값에는 앞의 값의 +1
//            Console.WriteLine((int)DialogResult.CANCEL); //12
//            Console.WriteLine((int)DialogResult.CONFIRM); //50
//            Console.WriteLine((int)DialogResult.OK); //51 --앞의 값의 +1
//        }
//    }
//}
////Nullable형식
//using System;

//namespace Nullable
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            int? a = null;

//            Console.WriteLine(a.HasValue); //값을 가지고 있는지 확인 null은 가지고 있지 않다=>false 출력
//            Console.WriteLine(a != null); //이또한 비어있는지 확인하는것

//            a = 3;

//            Console.WriteLine(a.HasValue); //값을 가졌으니
//            Console.WriteLine(a != null); //당연히 true
//            Console.WriteLine(a.Value); //값을 출력시킴
//        }
//    }
//}
//using System;

//namespace KoreaFlag
//{
//    class MainApp
//    {

//        static void Main(string[] args)
//        {
//            PrintWhite(40);
//            Console.WriteLine();

//            PrintWhite(6);
//            PrintBlack(2);
//            PrintWhite(24);
//            PrintBlack(2);
//            PrintWhite(6);
//            Console.WriteLine();

//            PrintWhite(5);
//            PrintBlack(2);
//            PrintWhite(1);
//            PrintBlack(2);
//            PrintWhite(20);
//            PrintBlack(2);
//            PrintWhite(1);
//            PrintBlack(2);
//            PrintWhite(5);
//            Console.WriteLine();

//            PrintWhite(4);
//            PrintBlack(2);
//            PrintWhite(1);
//            PrintBlack(2);
//            PrintWhite(1);
//            PrintBlack(2);
//            PrintWhite(16);
//            PrintBlack(2);
//            PrintWhite(1);
//            PrintBlack(2);
//            PrintWhite(7);
//            Console.WriteLine();

//            PrintWhite(3);
//            PrintBlack(2);
//            PrintWhite(1);
//            PrintBlack(2);
//            PrintWhite(1);
//            PrintBlack(2);
//            PrintWhite(18);
//            PrintBlack(2);
//            PrintWhite(1);
//            PrintBlack(2);
//            PrintWhite(1);
//            PrintBlack(2);
//            PrintWhite(3);
//            Console.WriteLine();

//            PrintWhite(2);
//            PrintBlack(2);
//            PrintWhite(1);
//            PrintBlack(2);
//            PrintWhite(1);
//            PrintBlack(2);
//            PrintWhite(7);
//            PrintRed(6);
//            PrintWhite(10);
//            PrintBlack(2);
//            PrintWhite(1);
//            PrintBlack(2);
//            PrintWhite(2);
//            Console.WriteLine();

//            PrintWhite(4);
//            PrintBlack(2);
//            PrintWhite(1);
//            PrintBlack(2);
//            PrintWhite(6);
//            PrintRed(10);
//            PrintWhite(6);
//            PrintBlack(2);
//            PrintWhite(1);
//            PrintBlack(2);
//            PrintWhite(4);
//            Console.WriteLine();

//            PrintWhite(6);
//            PrintBlack(2);
//            PrintWhite(6);
//            PrintRed(12);
//            PrintWhite(6);
//            PrintBlack(2);
//            PrintWhite(6);
//            Console.WriteLine();

//            PrintWhite(14);
//            PrintRed(13);
//            PrintWhite(13);
//            Console.WriteLine();

//            PrintWhite(13);
//            PrintRed(15);
//            PrintWhite(12);
//            Console.WriteLine();

//            PrintWhite(13);
//            PrintRed(15);
//            PrintWhite(12);
//            Console.WriteLine();

//            PrintWhite(12);
//            PrintBlue(1);
//            PrintRed(9);
//            PrintBlue(4);
//            PrintRed(3);
//            PrintWhite(11);
//            Console.WriteLine();

//            PrintWhite(12);
//            PrintBlue(1);
//            PrintRed(8);
//            PrintBlue(6);
//            PrintRed(2);
//            PrintWhite(11);
//            Console.WriteLine();

//            PrintWhite(12);
//            PrintBlue(2);
//            PrintRed(6);
//            PrintBlue(7);
//            PrintRed(2);
//            PrintWhite(11);
//            Console.WriteLine();

//            PrintWhite(12);
//            PrintBlue(3);
//            PrintRed(4);
//            PrintBlue(9);
//            PrintRed(1);
//            PrintWhite(11);
//            Console.WriteLine();

//            PrintWhite(13);
//            PrintBlue(15);
//            PrintWhite(12);
//            Console.WriteLine();

//            PrintWhite(13);
//            PrintBlue(15);
//            PrintWhite(12);
//            Console.WriteLine();

//            PrintWhite(14);
//            PrintBlue(13);
//            PrintWhite(13);
//            Console.WriteLine();

//            PrintWhite(6);
//            PrintBlack(2);
//            PrintWhite(6);
//            PrintBlue(12);
//            PrintWhite(6);
//            PrintBlack(2);
//            PrintWhite(6);
//            Console.WriteLine();

//            PrintWhite(4);
//            PrintBlack(2);
//            PrintWhite(1);
//            PrintBlack(2);
//            PrintWhite(6);
//            PrintBlue(10);
//            PrintWhite(6);
//            PrintBlack(2);
//            PrintWhite(1);
//            PrintBlack(2);
//            PrintWhite(4);
//            Console.WriteLine();

//            PrintWhite(2);
//            PrintBlack(2);
//            PrintWhite(1);
//            PrintBlack(2);
//            PrintWhite(1);
//            PrintBlack(2);
//            PrintWhite(7);
//            PrintBlue(6);
//            PrintWhite(10);
//            PrintBlack(2);
//            PrintWhite(1);
//            PrintBlack(2);
//            PrintWhite(2);
//            Console.WriteLine();

//            PrintWhite(3);
//            PrintBlack(2);
//            PrintWhite(4);
//            PrintBlack(2);
//            PrintWhite(18);
//            PrintBlack(2);
//            PrintWhite(4);
//            PrintBlack(2);
//            PrintWhite(3);
//            Console.WriteLine();

//            PrintWhite(4);
//            PrintBlack(2);
//            PrintWhite(1);
//            PrintBlack(2);
//            PrintWhite(1);
//            PrintBlack(2);
//            PrintWhite(16);
//            PrintBlack(2);
//            PrintWhite(1);
//            PrintBlack(2);
//            PrintWhite(7);
//            Console.WriteLine();

//            PrintWhite(5);
//            PrintBlack(2);
//            PrintWhite(1);
//            PrintBlack(2);
//            PrintWhite(20);
//            PrintBlack(2);
//            PrintWhite(1);
//            PrintBlack(2);
//            PrintWhite(5);
//            Console.WriteLine();

//            PrintWhite(6);
//            PrintBlack(2);
//            PrintWhite(24);
//            PrintBlack(2);
//            PrintWhite(6);
//            Console.WriteLine();

//            PrintWhite(40);
//            Console.WriteLine();
//        }
//        static void PrintWhite(int num)
//        {
//            Console.BackgroundColor = ConsoleColor.White;
//            for (int i = 0; i < num; i++) Console.Write("  ");
//            Console.BackgroundColor = ConsoleColor.Black;
//        }
//        static void PrintBlack(int num)
//        {
//            Console.BackgroundColor = ConsoleColor.Black;
//            for (int i = 0; i < num; i++) Console.Write("  ");
//        }
//        static void PrintRed(int num)
//        {
//            Console.BackgroundColor = ConsoleColor.Red;
//            for (int i = 0; i < num; i++) Console.Write("  ");
//            Console.BackgroundColor = ConsoleColor.Black;
//        }
//        static void PrintBlue(int num)
//        {
//            Console.BackgroundColor = ConsoleColor.Blue;
//            for (int i = 0; i < num; i++) Console.Write("  ");
//            Console.BackgroundColor = ConsoleColor.Black;
//        }

//    }
//}
////var(암시적 형식)
//using System;

//namespace UsingVar
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            var a = 20; //var형 변수를 선언할 때는 꼭 초기화
//            Console.WriteLine("Type : {0}, Value: {1}", a.GetType(), a); //정수형으로 판단하여 저장함을 확인할 수 있다.

//            var b = 3.1414213;
//            Console.WriteLine("Type : {0}, Value: {1}", b.GetType(), b); //double형으로 판단하여 저장!

//            var c = "Hello, World!";
//            Console.WriteLine("Type : {0}, Value: {1}", c.GetType(), c); //String형으로 판단하여 저장!

//            var d = new int[] { 10, 20, 30 }; //배열도 var로 선언 가능
//            Console.Write("Type : {0}, Value ", d.GetType());
//            foreach (var e in d) //배열의 각 요소 순환하는 for each
//                Console.Write("{0}", e);

//            Console.WriteLine();
//        }
//    }
//}
////문자열 탐색 프로그램 --string의 메소드들
//using static System.Console;

//namespace StringSearch
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            string greeting = "Good Morning";

//            WriteLine(greeting);
//            WriteLine();

//            //IndexOf() --인덱스 반환
//            WriteLine("IndexOf 'Good' : {0}", greeting.IndexOf("Good")); //첫번째로 탐색된 '문자열'의 인덱스를 반환한다
//            WriteLine("IndexOf 'o' : {0}", greeting.IndexOf('o')); //첫번째로 탐색된 문자의 인덱스를 반환한다.

//            //LastIndexOf()
//            WriteLine("LastIndexOf 'Good' : {0}", greeting.LastIndexOf("Good")); //뒤에서 첫번째 문자열 인덱스
//            WriteLine("LastindexOf 'o' : {0}", greeting.LastIndexOf('o')); //뒤에서 첫번째  문자의 인덱스

//            //startsWith()
//            WriteLine("StartsWith 'Good' : {0}", greeting.StartsWith("Good")); // 시작 문자열인지 확인 
//            WriteLine("StartsWith 'Morning' : {0}", greeting.StartsWith("Morning")); //Good로 시작하고 있으므로 얘는 false

//            //EndsWith()
//            WriteLine("EndsWith 'Good' : {0}", greeting.EndsWith("Good")); //마지막 문자열인지 확인
//            WriteLine("EndsWith 'Morning : {0}", greeting.EndsWith("Morning")); //뒤부터는 얘가 먼저 -- true

//            //Contains()
//            WriteLine("Contains 'Evening' : {0}", greeting.Contains("Evening")); //포함 여부 true/false
//            WriteLine("Contains 'Morning' : {0}", greeting.Contains("Morning"));

//            //Replace()
//            WriteLine("Replaced 'Morning' with 'Evening' : {0}", greeting.Replace("Morning", "Evening")); //문자열 바꾸기!
//        }
//    }
//}
////문자열 변형
//using static System.Console;

//namespace StringModify
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            WriteLine("ToLower() : {0}", "ABC".ToLower()); //이렇게 바로 메서드 사용가능!
//            WriteLine("ToUpper() : {0}", "abc".ToUpper()); //각각 대문자로, 소문자로 변환

//            WriteLine("Insert() : {0}", "Happy Friday!".Insert(5, "Sunny")); //원하는 위치에 문자열 삽입
//            WriteLine("Remove() : {0}", "I Don't Love You.".Remove(2, 6)); //원하는 위치에서 사이즈만큼 제거

//            WriteLine("Trim() : {0}", " No Spaces ".Trim()); //"앞/뒤"에 있는 공백을 삭제한 문자열 반환!!--공백 모두 제거인줄..
//            WriteLine("TrimStart() : {0}", " No Spaces ".TrimStart()); //문자열 앞에 있는 공백 삭제한 새 문자열
//            WriteLine("TrimEnd() : {0}", " No Spaces ".TrimEnd()); //문자열 뒤에 있는 공백 삭제한 새 문자열

//        }
//    }
//}
////문자열 분할
//using System;
//using static System.Console;

//namespace StringSlice
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            string greeting = "Good morning.";

//            WriteLine(greeting.Substring(0, 5)); //슬라이싱 --0번인덱스에 위치한 문자부터 5개까지
//            WriteLine(greeting.Substring(5)); //5번인덱스에 위치한 문자부터 끝까지!
//            WriteLine();

//            //String[] arr = greeting.Split(new string[] { " " }, StringSplitOptions.None);//공백 기준으로 쪼개기
//            //그나저나 이렇게 불편하게 해야하나...
//            String[] arr = greeting.Split(' ');//이렇게 해도 된다 음... 스플릿은 조금더 조사해볼까
//            WriteLine("Word Count : {0}", arr.Length);

//            foreach (string element in arr) //각 요소들 출력
//                WriteLine("{0}", element);
//        }
//    }
//}
////split 추가 예제
//namespace PlusSplit
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

//            string text = "one/ttwo three:four,five six seven";
//            System.Console.WriteLine($"Original text: '{text}'");

//            string[] words = text.Split(delimiterChars); //이렇게 구분자 배열을 넣어주면
//            System.Console.WriteLine($"{words.Length} words in text:");

//            foreach(var word in words)
//            {
//                System.Console.WriteLine($"<{word}>");
//            }
//        }
//    }
//}
////Format() 메소드 - 오른쪽/왼쪽 맞춤
//using System;
//using static System.Console;

//namespace StringFormatBasic
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            string fmt = "{0,-20}{1,-15}{2,30}"; //이렇게 하나의 포매팅 문자열 생성해서 

//            WriteLine(fmt, "Publisher", "Author", "Title"); //데이터들을 가지런히 출력시킬 수 있다!
//            WriteLine(fmt, "Marvel", "Stan Lee", "Iron Man");
//            WriteLine(fmt, "Hanbit", "Sanghyun Park", "This is C#");
//            WriteLine(fmt, "Prentice Hall", "K&R", "The C Programming Language");
//        }
//    }
//}
////숫자 서식 지정자
//using System;
//using static System.Console;

//namespace StringFormatNumber
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            // D : 10진수
//            WriteLine("10진수 : {0:D}",123); //WriteLine(string.Format("10진수: {0:D}",123))과 동일
//            WriteLine("10진수 : {0:D5}", 123); //5자리 숫자 형태로 출력 앞의 빈공간 0으로 출력됨
//            //자릿수 지정자는 서식문자 뒤에 

//            // X : 16진수 
//            WriteLine("16진수 : 0x{0:X}", 0xFF1234); //16진수 형태 그대로 출력하기 위해서는 포매팅을 해줘야함
//            WriteLine("16진수 : 0x{0:X8}", 0xFF1234); //숫자를 추가하면 자릿수 맞춰서 출력됨

//            // N : 숫자
//            WriteLine("숫자 : {0:N}", 123456789); //콤마로 구분해서 출력됨(세자리마다) 그리고 디폴트로 소수점 이하 두자리 출력된다
//            WriteLine("숫자 : {0:N0}", 123456789); //자릿수 지정해 소수점이하를 제거 할 수 있다

//            // F : 고정 소수점
//            WriteLine("고정 소수점: {0:F}", 123.45);
//            WriteLine("고정 소수점: {0:F5}", 123.456); //고정소수점에서는 소수점 이하 자릿수가 지정됨

//            // E : 공학용
//            WriteLine("공학 : {0:E}", 123.456789); //지수 형식 서식 지정
//        }
//    }
//}
////3장 연습문제 1.
//using System;

//namespace RectArea
//{
//    class MainApp
//    {
//        public static void Main()
//        {
//            Console.WriteLine("사각형의 너비를 입력하세요.");
//            string width = Console.ReadLine(); //문자열로 너비를 입력받음

//            Console.WriteLine("사각형의 높이를 입력하세요.");
//            string height = Console.ReadLine();

//            //사각형의 넓이를 계산
//            int widthNum = int.Parse(width); int heightNum = int.Parse(height);
//            int result = widthNum * heightNum;
//            //출력
//            Console.WriteLine("사각형의 넓이는 : {0}", result);
//        }
//    }
//}
////산술 연산자
//using System;

//namespace ArithmaticOperators
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            int a = 111 + 222; //덧셈
//            Console.WriteLine($"a: {a}"); //문자열 보간 방식!

//            int b = a - 100; //뺄셈
//            Console.WriteLine($"b: {b}");

//            int c = b * 10; //곱셈
//            Console.WriteLine($"c: {c}");

//            double d = c / 6.3; //나눗셈
//            Console.WriteLine($"d: {d}"); //소수점까지 보려면 피연산자중 하나가 소수점표시가 있어야함

//            Console.WriteLine($"22 / 7 = {22 / 7}({22 % 7})"); //몫과 나머지
//        }
//    }
//}
////증감 연산자
//using System;

//namespace IncDecOperator
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            int a = 10;
//            Console.WriteLine(a++); //WriteLine에 값을 전달하고 증가시킴(전위 증가 연산자)
//            Console.WriteLine(++a); //값을 증가시키고 WriteLien에 전달(후위 증가 연산자)
//            //앞에 붙을때와 뒤에 붙을때 동작 방식에 유의하자
//            Console.WriteLine(a--);
//            Console.WriteLine(--a);
//        }
//    }
//}
////문자열 결합 연산자
//using System;

//namespace StringConcatenate
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            string result = "123" + "456"; //산술 연산자  + 가 아닌 결합 연산자 + !!
//            Console.WriteLine(result); //123456

//            result = "Hello" + " " + "World!"; //즉 이렇게 문자열을 계속 이어붙일 수 있다!
//            Console.WriteLine(result);
//        }
//    }
//}
////관계 연산자
//using System;

//namespace RelationalOperateor
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine($"3 > 4 : {3 > 4}");
//            Console.WriteLine($"3 >= 4 : {3 >= 4}");
//            Console.WriteLine($"3 < 4 : {3 < 4}");
//            Console.WriteLine($"3 <= 4 : {3 <= 4}");
//            Console.WriteLine($"3 == 4 : {3 == 4}");
//            Console.WriteLine($"3 != 4 : {3 != 4}");
//        }
//    }
//}
////논리 연산자
//using System;

//namespace LogicalOperator
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Testing && ...");
//            Console.WriteLine($"1 > 0 && 4 < 5 : {1 > 0 && 4 < 5}");
//            Console.WriteLine($"1 > 0 && 4 > 5 : {1 > 0 && 4 > 5}");
//            Console.WriteLine($"1 == 0 && 4 > 5 : {1 == 0 && 4 > 5}");
//            Console.WriteLine($"1 == 0 && 4 < 5 : {1 == 0 && 4 < 5}");

//            Console.WriteLine("\nTesting || ...");
//            Console.WriteLine($"1 > 0 || 4 < 5 : {1 > 0 || 4 < 5}");
//            Console.WriteLine($"1 > 0 || 4 > 5 : {1 > 0 || 4 > 5}");
//            Console.WriteLine($"1 == 0 || 4 > 5 : {1 == 0 || 4 > 5}");
//            Console.WriteLine($"1 == 0 || 4 < 5 : {1 == 0 || 4 < 5}");

//            Console.WriteLine("\nTesting ! ...");
//            Console.WriteLine($"!True : {!true}");
//            Console.WriteLine($"!False : {!false}");

//        }
//    }
//}
////조건 연산자
//using System;

//namespace ConditionalOperator
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            string result = (10 % 2) == 0 ? "짝수" : "홀수"; //10을 2로 나눈 나머지가 0이면

//            Console.WriteLine(result); //짝수가 출력되고 아니면 홀수가 출력된다!
//        }
//    }
//}
////null 조건부 연산자
//using System.Collections;
//using static System.Console;

//namespace NullContitionalOperator
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            ArrayList a = null; //객체 선언 null로 초기화
//            a?.Add("야구"); //a?. 가 null을 반환하므로 Add() 메소드는 호출되지 않음
//            //멤버(메소드)에 접근하기 전 객체가 null이기 때문에 null반환 즉, 멤버(메소드)를 호출하지 않는다
//            a?.Add("축구"); //마찬가지!
//            WriteLine($"Count : {a?.Count}");//마찬가지로 출력되지 않음!
//            WriteLine($"{a?[0]}"); //객체가 null이 아니면 0번 인덱스에 해당하는 값을 출력했겠지
//            WriteLine($"{a?[1]}"); //마찬가지

//            a = new ArrayList(); //이제 널이 아니게된 객체!
//            a?.Add("야구");
//            a?.Add("축구");
//            WriteLine($"Count : {a?.Count}");
//            WriteLine($"{a?[0]}");
//            WriteLine($"{a?[1]}");
//            //모두 정상 출력됨!
//        }
//    }
//}
////시프트 연산자
//using System;

//namespace ShiftOperator
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Testing << ...");

//            int a = 1; //0000 0000 0000 0000 0000 0000 0000 0001 (4바이트 기준!)
//            Console.WriteLine("a      : {0:D5} (0x{0:X8})", a); //8자리 16진수(=4바이트)로 표현 가능!
//            Console.WriteLine("a << 1 : {0:D5} (0x{0:X8})", a << 1); //왼쪽으로 1만큼 이동 (x2)
//            Console.WriteLine("a << 2 : {0:D5} (0x{0:X8})", a << 2); //왼쪽으로 2만큼 이동 (x2^2)
//            Console.WriteLine("a << 5 : {0:D5} (0x{0:X8})", a << 5); //왼쪽으로 5만큼 이동 (x2^5)

//            Console.WriteLine("\nTesting >> ...");

//            int b = 255; //0000 0000 0000 0000 0000 0000 1111 1111
//            Console.WriteLine("b      : {0:D5} (0x{0:X8})", b);
//            Console.WriteLine("b << 1 : {0:D5} (0x{0:X8})", b >> 1); //오른쪽으로 1만큼 이동 (/2)
//            Console.WriteLine("b << 2 : {0:D5} (0x{0:X8})", b >> 2); //오른쪽으로 2만큼 이동 (/2^2)
//            Console.WriteLine("b << 5 : {0:D5} (0x{0:X8})", b >> 5); //오른쪽으로 5만큼 이동 (/2^5)

//            Console.WriteLine("\nTesting >> 2 ..."); //2의 보수법에서의 시프트 연산

//            int c = -255; //1111 1111 1111 1111 1111 1111 0000 0001
//            Console.WriteLine("c      : {0:D5} (0x{0:X8})", c);
//            Console.WriteLine("c << 1 : {0:D5} (0x{0:X8})", c >> 1); //1111 1111 1111 1111 1111 1111 1000 0000 
//            Console.WriteLine("c << 2 : {0:D5} (0x{0:X8})", c >> 2); //1111 1111 1111 1111 1111 1111 1100 0000
//            Console.WriteLine("c << 5 : {0:D5} (0x{0:X8})", c >> 5); //1111 1111 1111 1111 1111 1111 1111 1000
//        }
//    }
//}
////비트 논리 연산자
//using System;

//namespace BitwiseOperator
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            int a = 9; //1001
//            int b = 10; //1010

//            Console.WriteLine($"{a} & {b} : {a & b}"); //논리곱 : 1001 & 1010 = 1000
//            Console.WriteLine($"{a} | {b} : {a | b}"); //논리합 : 1001 | 1010 = 1011
//            Console.WriteLine($"{a} ^ {b} : {a ^ b}"); //배타적 논리합 : 1001 ^ 1010 = 0011

//            int c = 255;
//            Console.WriteLine("~{0}(0x{0:X8}) : {1}(0x{1:X8})", c, ~c);
//        }
//    }
//}
////할당 연산자
//using System;

//namespace AssignmentOperator
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            int a;
//            a = 100;
//            Console.WriteLine($"a = 100 : {a}");
//            a += 90;
//            Console.WriteLine($"a += 90 : {a}");
//            a -= 80;
//            Console.WriteLine($"a -= 80 : {a}");
//            a *= 70;
//            Console.WriteLine($"a *= 70 : {a}");
//            a /= 60;
//            Console.WriteLine($"a /= 60 : {a}");
//            a %= 50;
//            Console.WriteLine($"a %= 50 : {a}");
//            a &= 40;
//            Console.WriteLine($"a &= 40 : {a}");
//            a |= 30;
//            Console.WriteLine($"a |= 30 : {a}");
//            a ^= 20;
//            Console.WriteLine($"a ^= 20 : {a}");
//            a <<= 10;
//            Console.WriteLine($"a <<= 10 : {a}");
//            a >>= 1;
//            Console.WriteLine($"a >>= 1 : {a}");
//        }
//    }
//}
////null 병합 연산자
//using System;

//namespace NullCoalescing
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            int? num = null;
//            Console.WriteLine($"{num ?? 0}"); //0

//            num = 99;
//            Console.WriteLine($"{num ?? 0}"); //99

//            string str = null;
//            Console.WriteLine($"{str ?? "Default"}"); //Default

//            str = "Specific";
//            Console.WriteLine($"{str ?? "Default"}"); //Specific
//        }
//    }
//}
////if, else, else if
//using System;

//namespace IfElse
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            Console.Write("숫자를 입력하세요. :");

//            string input = Console.ReadLine();//문자열로 입력받아서
//            int number = Int32.Parse(input);//정수형으로 변환

//            if (number < 0) //0보다 작으면
//                Console.WriteLine("음수");
//            else if (number > 0) //0보다 크면
//                Console.WriteLine("양수");
//            else //0이면(둘다 아니니까)
//                Console.WriteLine("0");

//            if (number % 2 == 0) //2로 나눈게 0이면
//                Console.WriteLine("짝수");
//            else //0이 아니니까
//                Console.WriteLine("홀수");
//        }
//    }
//}
////if문 중첩
//using System;

//namespace IfIf
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            Console.Write("숫자를 입력하세요. : ");

//            string input = Console.ReadLine();
//            int number = Convert.ToInt32(input);

//            if(number>0)
//            {
//                if (number % 2 == 0) //이렇게 중첩해서 사용할 수 있다.
//                    Console.WriteLine("0보다 큰 짝수.");
//                else
//                    Console.WriteLine("0보다 큰 홀수.");
//            }
//            else
//            {
//                Console.WriteLine("0보다 작거나 같은 수.");
//            }
//        }
//    }
//}
////switch문
//using System;

//namespace Switch
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            Console.Write("요일을 입력하세요.(일,월,화,수,목,금,토) : ");
//            string day = Console.ReadLine();

//            switch(day)
//            {
//                case "일":
//                    Console.WriteLine("Sunday");
//                    break;
//                case "월":
//                    Console.WriteLine("Monday");
//                    break;
//                case "화":
//                    Console.WriteLine("Tuesday");
//                    break;
//                case "수":
//                    Console.WriteLine("Wednesday");
//                    break;
//                case "목":
//                    Console.WriteLine("Thursday");
//                    break;
//                case "금":
//                    Console.WriteLine("Friday");
//                    break;
//                case "토":
//                    Console.WriteLine("Saturday");
//                    break;
//                default:
//                    Console.WriteLine($"{day}는(은) 요일이 아닙니다.");
//                    break;
//            }
//        }
//    }
//}
////switch문과 패턴 매칭
//using System;

//namespace Switch2
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            object obj = null; //변수(객체) 선언

//            string s = Console.ReadLine(); //문자열로 입력을 받음
//            if (int.TryParse(s, out int out_i)) //그냥 Parse()메소드는 변환 실패시 예외 발생, 코드 실행을 멈춤
//                obj = out_i; //반면 TryParse는 변환 성공 여부를 반환하고 성공하면 두번째 매개변수에 그 값을 저장
//            else if (float.TryParse(s, out float out_f)) //out 키워드는 출력 전용 매개변수임을 나타내는 것
//                obj = out_f;
//            else
//                obj = s;

//            switch(obj)
//            {
//                case int i when i>0 : //양수인건 여기서
//                    Console.WriteLine($"{(int)obj}는 int 형식이며 0보다 큽니다.");
//                    break;
//                case int: //아닌 정수는 여기서
//                    Console.WriteLine($"{(int)obj}는 int 형식입니다.");
//                    break;
//                case float:
//                    Console.WriteLine($"{(float)obj}는 float 형식입니다.");
//                    break;
//                default:
//                    Console.WriteLine($"{obj}(은)는 모르는 형식입니다.");
//                    break;
//            }
//        }
//    }
//}
//using System;

//namespace SwitchExp
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("점수를 입력하세요.");
//            int score = Convert.ToInt32(Console.ReadLine());

//            Console.WriteLine("재수강인가요? (y/n)");
//            string line = Console.ReadLine();
//            bool repeated = line == "y" ? true : false;

//            string grade = (int)(Math.Truncate(score / 10.0) * 10) switch
//            {                   //Trucate() 1의자리 버림!
//                90 when repeated == true => "B+", //케이스 가드 적용한 것
//                90 => "A", //스위치 식 변환
//                /*원래는 case 90: grade="A"; break;*/
//                80 => "B", //다음 케이스로 넘어갈때는 ,
//                70 => "c", 
//                60 => "D",
//                _ => "F" //default는 _
//            };

//            Console.WriteLine($"학점 : {grade}");
//        }
//    }
//}
////while
//using System;

//namespace While
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            int i = 10;

//            while(i>0) //이 조건을 만족(true)하는 동안 반복
//            {
//                Console.WriteLine($"i : {i--}");
//            }
//        }
//    }
//}
////do while
//using System;

//namespace While
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            int i = 10;
//            do //일단 실행시키고
//            {
//                Console.WriteLine("a) i : {0}", i--);
//            }
//            while (i > 0); //조건 검사 --만족하지 못하면 루프 탈출

//            do //이미 0이지만 한번 실행하고
//            {
//                Console.WriteLine("b) i : {0}", i--);
//            }
//            while (i > 0); //여기에 걸려서 바로 나옴
//        }
//    }
//}
////for
//using System;

//namespace For
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            for(int i=0;i<5;i++) //5번 반복
//            {
//                Console.WriteLine(i); //0~4까지 출력될것
//            }
//        }
//    }
//}
////중첩 for
//using System;

//namespace ForFor
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            for(int i=0;i<5;i++) //크게 5번
//            {//즉 i=0일때 , i=1일때, ...
//                for(int j=0;j<=i;j++) //작게 i번
//                {//j=0만 수행, j=0,1수행 ...
//                    Console.Write("*");
//                }
//                Console.WriteLine(); //크게 한번 돌때마다 개행
//            }
//        }
//    }
//}
////foreach
//using System;

//namespace ForEach
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = new int[] { 0, 1, 2, 3, 4 }; //C# 배열의 선언법

//            foreach (int a in arr) //각 배열 요소에 접근. 이름을 a로 임시 사용
//            {
//                Console.WriteLine(a); //각 a들을 출력시킴
//            }
//        }
//    }
//}
////무한 반복 코드 --for
//using System;

//namespace InfiniteFor
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            int i = 0;
//            for (; ; ) //아무런 조건식이 없기 때문에 무한 반복됨
//                Console.WriteLine(i++);
//        }
//    }
//}
////무한 반복 코드 --while
//using System;

//namespace InfiniteWhile
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            int i = 0;
//            while (true) //조건식 자리에 true가 옴으로써 무한 반복(탈출 조건이 없음)
//                Console.WriteLine(i++);
//        }
//    }
//}
////break
//using System;

//namespace Break
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            while(true) //무한 반복 코드
//            {
//                Console.Write("계속할까요?(예/아니오) : ");
//                string answer = Console.ReadLine();

//                if (answer == "아니오") //탈출 조건
//                    break; //탈출
//            }
//        }
//    }
//}
////continue
//using System;

//namespace Continue
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            for(int i=0;i<10;i++)
//            {
//                if (i % 2 == 0) //2로 나눈 나머지가 0이면
//                    continue; //아래 코드 다 무시하고 다음 회차로 넘어감

//                Console.WriteLine($"{i} : 홀수"); //여기는 0으로 나눈 나머지가 0이 아닌애들만 수행됨
//            }
//        }
//    }
//}
////goto
//using System;

//namespace Goto
//{
//    class MainApp
//    {
//        static void Main(string[] args)
//        {
//            Console.Write("종료 조건(숫자)을 입력하세요. :");

//            string input = Console.ReadLine();

//            int input_number = Convert.ToInt32(input);

//            int exit_number = 0;

//            for(int i=0;i<2;i++) //3번을 각 2번하는것을 2번더 ==>12번 반복하는 반복문
//            {
//                for(int j=0;j<2;j++) //3번을 각 2번
//                {
//                    for(int k=0;k<3;k++) //각 3번
//                    {
//                        if (exit_number++ == input_number) //종료숫자가 되면
//                            goto EXIT_FOR; //EXIT_FOR로 이동

//                        Console.WriteLine(exit_number);
//                    }
//                }
//            }
//            goto EXIT_PROGRAM; //반복문에 정해진 횟수(12)를 넘어가 종료되면 이게 먼저 수행됨

//        EXIT_FOR:
//            Console.WriteLine("\nExit nested for..."); //반복문 도는 도중 탈출
//        EXIT_PROGRAM:
//            Console.WriteLine("Exit program..."); //프로그램의 종료를 알리는 메시지
//        }
//    }
//}
////형식 패턴을 활용한 예제
//using System;
//class Preschooler { } //사용자 정의 자료형 -클래스!
//class Underage { }
//class Adult { }
//class Senior { }

//internal class MainApp
//{
//    static int CalculateFee(object visitor)
//    {
//        return visitor switch
//        {
//            Underage => 100, //각 형식에 매칭되면
//            Adult => 500, //각 값 리턴
//            Senior => 200,
//            _ => throw new ArgumentException( //해당하지 않으면 예외발생
//                $"Prohibited age: {visitor.GetType()}", nameof(visitor)),
//        };
//    }

//    static void Main(string[] args)
//    {
//        Console.WriteLine($"Fee for a Senior: {CalculateFee(new Senior())}");
//        Console.WriteLine($"Fee for a adult: {CalculateFee(new Adult())}");
//        Console.WriteLine($"Fee for a underage: {CalculateFee(new Underage())}");
//        Console.WriteLine($"Fee for a preschooler: {CalculateFee(new Preschooler())}");

//    }
//}
////상수 패턴 매칭 예제
//using System;

////반환형 함수명    정의(람다식)   함수인자  반환인자
//var GetCountryCode = (string nation) => nation switch 
//{ //함수인자에 따라 값 바로 할당
//    "KR" => 82,
//    "US" => 1,
//    "UK" => 44,
//    _ => throw new ArgumentException("Not supported Code") //해당하는것 없으면 예외발생
//};

//Console.WriteLine(GetCountryCode("KR"));
//Console.WriteLine(GetCountryCode("US"));
//Console.WriteLine(GetCountryCode("UK"));
////프로퍼티 패턴 예제
//using System;
//class MainApp
//{
//    class Car
//    {
//        public string Model { get; set; } //C++ 에서 멤버 값 일일히 설정함수나 값을 가져오는 함수를 만들어야 했다면
//        public DateTime ProduceAt { get; set; } //C#에서는 이렇게 프러퍼티를 이용해 간단히 만들 수 있다
//    }
//    static string GetNickname(Car car)
//    {
//        var GenerateMessage = (Car car, string nickname) => //람다식 정의
//        $"{car.Model} produced in {car.ProduceAt.Year} is {nickname}";
//        //if (car is Car { Model: "Mustang", ProduceAt.Year: 1967 }) //1967년산 무스탕이면
//        //    return GenerateMessage(car, "Fastback"); 
//        //else if (car is Car { Model: "Mustang", ProduceAt.Year: 1976 }) //1976년산 무스탕이면
//        //    return GenerateMessage(car, "cobra II");
//        //else
//        //    return GenerateMessage(car, "Unknown"); //그외
//        //추가 문제  -- is 연산자가 아닌 switch 이용
//        return car switch
//        {
//            Car { Model: "Mustang", ProduceAt.Year: 1967 } => GenerateMessage(car, "Fastback"),
//            Car { Model: "Mustang", ProduceAt.Year: 1976 } => GenerateMessage(car, "cobra II"),
//            _ => GenerateMessage(car, "Unknown")
//        };
//    }
//    static void Main(string[] args)
//    {
//        Console.WriteLine(
//            GetNickname(
//                new Car() { Model = "Mustang", ProduceAt = new DateTime(1967, 11, 23) }));
//        Console.WriteLine(
//            GetNickname(
//                new Car() { Model = "Mustang", ProduceAt = new DateTime(1976, 6, 7) }));
//        Console.WriteLine(
//            GetNickname(
//                new Car() { Model = "Mustang", ProduceAt = new DateTime(2099, 12, 25) }));
//    }
//}
////논리 패턴
//using System;
//class MainApp
//{
//    class OrderItem
//    {
//        public int Amount { get; set; } //프러퍼티
//        public int Price { get; set; }
//    }
//    //GetPrice 함수 정의
//    static double GetPrice(OrderItem orderItem) => orderItem switch
//    { //각 조건에 맞음을 검사!
//        OrderItem { Amount: 0 } or OrderItem { Price: 0 }               //or
//            => 0.0,
//        OrderItem { Amount: >= 100 } and OrderItem { Price: >= 10_000 } //and
//        => orderItem.Amount * orderItem.Price * 0.8,
//        not OrderItem { Amount: < 0 }                                   //not
//        => orderItem.Amount * orderItem.Price * 0.9,
//        _ => orderItem.Amount * orderItem.Price,
//    };
//    static void Main(string[] args)
//    {
//        Console.WriteLine(GetPrice(new OrderItem() { Amount = 0, Price = 10_000 }));
//        Console.WriteLine(GetPrice(new OrderItem() { Amount = 100, Price = 10_000 }));
//        Console.WriteLine(GetPrice(new OrderItem() { Amount = 100, Price = 9_000 }));
//        Console.WriteLine(GetPrice(new OrderItem() { Amount = 1, Price = 1_000 }));
//    }
//}
////위치 패턴 switch 식
//using System;

//class MainApp
//{
//    struct Audience
//    {
//        public bool IsCitizen { get; init; }
//        public int Age { get; init; }

//        public Audience(bool isCitizen,int age) //구조체 멤버 초기화
//        {
//            IsCitizen = isCitizen;
//            Age = age;
//        }

//        public void Deconstruct(out bool isCitizen, out int age) //구조체 분해
//        {
//            isCitizen = IsCitizen;
//            age = Age;
//        }
//    }

//    static void Main(string[] args)
//    {
//        var CalculateFee = (Audience audience) => audience switch
//        {
//            (true, < 19) => 100, //분해된 값과 매칭하여 해당하는 값을 반환함
//            (true, _) => 200,
//            (false, < 19) => 200,
//            (false, _) => 400,
//        };
//        var a1 = new Audience(true, 10);
//        Console.WriteLine($"내국인: {a1.IsCitizen} 나이: {a1.Age} 요금: {CalculateFee(a1)}");

//        var a2 = new Audience(false, 33);
//        Console.WriteLine($"내국인: {a2.IsCitizen} 나이: {a2.Age} 요금: {CalculateFee(a2)}");

//    }
//}
////var 패턴
////모든 과목이 60점이 넘고, 평균이 60점 이상인 경우에만 Pass
//using System;
//using System.Linq;

//var IsPassed = (int[] scores) => scores.Sum() / scores.Length is var average //임시 변수 average에 값 할당
//                                 && Array.TrueForAll(scores, (score) => score >= 60) //배열의 요소가 모두 조건을 만족하면 true
//                                 && average >= 60; //임시 변수값에 조건 걸 수 있음
//int[] scores1 = { 90, 80, 60, 80, 70 };
//Console.WriteLine($"{string.Join(",", scores1)}: Pass:{IsPassed(scores1)}");

//int[] scores2 = { 90, 80, 59, 80, 70 };
//Console.WriteLine($"{string.Join(",", scores2)}: Pass:{IsPassed(scores2)}");
//목록 패턴의 사용!
using System.Collections.Generic;

var GetStatistics = (List<object[]>records)=>
{
    var statistics = new Dictionary<string, int>();

    foreach(var record in records)
    {
        var (contentType, contentViews) = record switch
        {

        }
    }
}