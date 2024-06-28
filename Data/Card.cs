using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using YuGiOh.Properties;

namespace YuGiOh.Data
{
    public enum CardType { Normal, Magic }
    public enum CardMode { Attack, Defence }


    public class Card
    {
        public string Name { get; set; }     //카드 이름
        public int Rank { get; set; }        //랭크(별)
        public int Attack { get; set; }      //공격력
        public int Defense { get; set; }     //방어력
        public string CardInfo { get; set; } //카드 정보
        public CardType Type { get; set; }   //카드 타입, 일반/특수
        public Image Image { get; set; }     //카드 이미지
        public string Function { get; set; } //특수 카드 효과
        public CardMode? Mode { get; set; }  //소환 시 배치 형태, 공격/수비

        public Card(string name)
        {
            Name = name;
        }

        public Card(string name, int rank, int attack, int defense, string cardInfo, CardType type, Image image)
        {
            Name = name;
            Rank = rank;
            Attack = attack;
            Defense = defense;
            CardInfo = cardInfo;
            Type = type;
            Image = image;
        }
        public Card(string name, int rank, int attack, int defense, string cardInfo, CardType type, Image image, string function)
        {
            Name = name;
            Rank = rank;
            Attack = attack;
            Defense = defense;
            CardInfo = cardInfo;
            Type = type;
            Image = image;
            Function = function;
        }

        public static List<Card> Load_Digimon_Card()
        {
            List<Card> list = new List<Card>();
            list.Add(new Card("가루몬", 2, 1000, 1200, "[WATER]\n청백은색의 모피로 몸을 싸고 있는 늑대와 같은 모습을 한 수형 디지몬\n그 체모는 전설의 레어메탈이라고 불리우는 미스릴 같이 딱딱하다", CardType.Normal, Resources.Digimon1));
            list.Add(new Card("가르고몬", 2, 1000, 1000, "[WIND]\n테리어몬이 진화한 수인형 디지몬으로 사냥이 특기인 헌터\n보이는 것과는 달리, 무자비한 성격이다.", CardType.Normal, Resources.Digimon2));
            list.Add(new Card("가트몬", 2, 1200, 900, "[LIGHT]\n몸집은 작지만 귀중한 신성계의 디지몬이며, 외형과는 어울리지 않는 실력을 보유 \n신성계의 증거인 홀리링을 꼬리에 지니고 있다.", CardType.Normal, Resources.Digimon3));
            list.Add(new Card("구미호몬", 2, 1100, 1000, "[FIRE]\n9개의 꼬리를 기른 거대한 여우의 모습을 한 요수형 디지몬\n고대에는 평화로운 세상에 나타나는 사자로 추앙받았다.", CardType.Normal, Resources.Digimon4));
            list.Add(new Card("그라우몬", 2, 1400, 1000, "[DARK]\n진홍빛 마룡으로 불리는 마룡형 디지몬.\n테이머의 명령을 충실히 따라 정의를 위해서 싸우기도 한다.", CardType.Normal, Resources.Digimon5));
            list.Add(new Card("그레이몬", 2, 1200, 1000, "[FIRE]\n머리부분의 피부가 딱딱해져 갑충과도 같은 껍질로 감싸여진 공룡형 디지몬\n성격도 거친데다 비상히 공격적인 몬스터.", CardType.Normal, Resources.Digimon6));
            list.Add(new Card("기가드라몬", 3, 1500, 1500, "[DARK]\n암흑룡 디지몬. 한층 더 개조하는 것으로 완전무장한\n전투룡으로 그 존재는 흉악한 컴퓨터 바이러스 그 자체이다.", CardType.Normal, Resources.Digimon7));
            list.Add(new Card("다크나이트몬", 3, 1600, 1500, "[DARK]\n의형의 지략과 행동력이 일체가 된 다크나이트몬은 일급의 전사가 된다.\n", CardType.Normal, Resources.Digimon8));
            list.Add(new Card("데블드라몬", 2, 1300, 1000, "[DARK]\n복안의 악마라 불리는 사룡디지몬\n이 정도로 사악한 디지몬은 거의 없다", CardType.Normal, Resources.Digimon9));
            list.Add(new Card("델타몬", 2, 1200, 1100, "[DARK]\n3개의 머리, 2개의 꼬리를 가진 디지몬\n한번에 세마리의 디지몬을 상대할 수 있다고 한다.", CardType.Normal, Resources.Digimon10));
            list.Add(new Card("도그몬", 2, 1000, 1300, "[EARTH]\n아메리카의 카툰 텔레비전의 데이터베이스로부터 태어난\n퍼펫형 디지몬 몸이 매우 부드럽고 단단하다.", CardType.Normal, Resources.Digimon11));
            list.Add(new Card("래피드몬", 3, 1400, 1300, "[WIND]\n광속에 근접한 움직임으로 확실히 적을 끝장낸다\n거대한 귀 모양의 레이더를 구사한다.", CardType.Normal, Resources.Digimon12));
            list.Add(new Card("레오몬", 2, 800, 1300, "[LIGHT]\n백수의 왕, 고상한 용사라 불리는 수인형 디지몬.\n광포한 디지몬들이 많은 가운데 강한 의지와 정의의 마음을 가지고 있다.", CardType.Normal, Resources.Digimon13));
            list.Add(new Card("레이디데블몬", 3, 1600, 1000, "[DARK]\n고귀한 존재의 여성형 타천사 디지몬\n", CardType.Normal, Resources.Digimon14));
            list.Add(new Card("로프몬", 1, 500, 500, "[DARK]\n생태계는 수수께끼에 싸여있어, 몸의 구조로부터 짐승형으로 분류되었지만\n그 이외엔 여전히 밝혀진 것이 없다.", CardType.Normal, Resources.Digimon15));
            list.Add(new Card("루체몬 폴다운 모드", 3, 1900, 1500, "[DARK]\n성과 마의 힘을 같이 가진 궁극의 마왕형 디지몬\n", CardType.Normal, Resources.Digimon16));
            list.Add(new Card("루체몬", 1, 1300, 1000, "[LIGHT]\n고대 디지털 월드에 강림했다고 하는 천사 디지몬\n혼돈되고 있었던 시대에 나타나 세계에 질서와 평화를 가져다주었다.", CardType.Normal, Resources.Digimon17));
            list.Add(new Card("매그너몬", 3, 1200, 1900, "[LIGHT]\n기적의 디지멘탈의 파워에 의해 진화한 아머체의 성기사형 디지몬\n", CardType.Normal, Resources.Digimon18));
            list.Add(new Card("메가로그라우몬", 3, 1700, 1500, "[FIRE]\n남아도는 파워로 폭주하는 것을 막기 위해\n턱 부분에 재갈 같은 구속구를 차고 있다.", CardType.Normal, Resources.Digimon19));
            list.Add(new Card("메탈그레이몬", 3, 1600, 1400, "[FIRE]\n몸의 절반 이상을 기계화한 사이보그형 디지몬.\n개조에 의해 생명활동을 대폭 증가시켰다.", CardType.Normal, Resources.Digimon20));
            list.Add(new Card("묘티스몬", 3, 1600, 1000, "[DARK]\n어둠의 술법으로 되살아나 생전보다 강대한 파워를\n손에 넣는 것에 성공한 언데드 디지몬의 왕", CardType.Normal, Resources.Digimon21));
            list.Add(new Card("브이드라몬", 2, 1300, 900, "[LIGHT]\n광대한 디지털 월드에서도, 폴더 대륙에만 존재하는 것으로\n알려져 있는 환상의 고대종 디지몬.", CardType.Normal, Resources.Digimon22));
            list.Add(new Card("브이몬", 1, 700, 600, "[LIGHT]\n디지털 월드의 창세기에 번영했던 종족의 후예로\n뛰어난 전투 종족에 놀라운 잠재력을 지니고 있다.", CardType.Normal, Resources.Digimon23));
            list.Add(new Card("블랙버드라몬", 2, 1200, 800, "[FIRE]\n어두운 색의 불꽃을 감싼 디지몬\n적에 대해서는 흉포할 정도로 반격을 거듭하는 성미를 가지고 있다.", CardType.Normal, Resources.Digimon24));
            list.Add(new Card("사이버드라몬", 3, 1600, 1600, "[EARTH]\n어떠한 공격에도 버틸 수 있는 특수한\n고무 장갑을 몸에 두른 용인계의 사이보그형 디지몬", CardType.Normal, Resources.Digimon25));
            list.Add(new Card("소울몬", 2, 900, 900, "[DARK]\n저주받은 바이러스 프로그램으로 구성된 고스트형 디지몬\n판타지에 등장하는 마법사의 데이터를 얻은 고스몬이다.", CardType.Normal, Resources.Digimon26));
            list.Add(new Card("스컬그레이몬", 3, 1800, 1000, "[DARK]\n싸우는 일만을 집착해온 디지몬이, 육체가 쇠락했음에도 상관하지\n않고 투쟁 본능만으로 살아나간 결과, 스컬그레이몬이 되어버렸다.", CardType.Normal, Resources.Digimon27));
            list.Add(new Card("아구몬", 1, 900, 500, "[FIRE]\n성장해 이족보행을 할 수 있게된 파충류형 디지몬\n성장 도중이라 힘은 약하지만 두려움을 모른다.", CardType.Normal, Resources.Digimon28));
            list.Add(new Card("아트라캅테리몬", 3, 1300, 1700, "[EAUGH]\n열대권의 넷 에리어 내에서 발견된 캅테리몬의 진화형종\n사이즈는 약 1.5배이며, 곤충형 중에서도 상당히 큰 편이다.", CardType.Normal, Resources.Digimon29));
            list.Add(new Card("안드로몬", 3, 1600, 1300, "[FIRE]\n인간형 사이보그 디지몬 완전체 이하라면\n한 방에 쓰러뜨리는 전투력을 지녔다.", CardType.Normal, Resources.Digimon30));
            list.Add(new Card("에테몬", 3, 1600, 1500, "[DARK]\n갑자기 디지털 월드에 나타난 정체불명의 디지몬\n킹 오브 디지몬을 자칭하고 있고, 그 전투력은 상상을 초월한다.", CardType.Normal, Resources.Digimon31));
            list.Add(new Card("엑스브이몬", 2, 1300, 1200, "[DIVINE]\n발달한 팔다리 힘에서 발휘되는 공격력은 굉장하며 산만큼\n커다란 암석조차 흔적도 없이 파괴할 수 있을 정도다.", CardType.Normal, Resources.Digimon32));
            list.Add(new Card("엔젤몬", 2, 1300, 1000, "[LIGHT]\n디지털 월드가 몇 번이고 위기에 처했을 때\n같은 종속의 디지몬들을 이끌고 강림했다 전해진다.", CardType.Normal, Resources.Digimon33));
            list.Add(new Card("엔젤우몬", 3, 1500, 1500, "[LIGHT]\n아름다운 여성의 모습을 한 대천사형 디지몬. 이전에는 천사형으로\n분류되고 있었지만, 그 높은 능력에 따라 대천사형으로 판명되었다. ", CardType.Normal, Resources.Digimon34));
            list.Add(new Card("우가몬", 2, 1200, 900, "[DARK]\n무섭게 발달한 근육에서 뿌려지는 공격은 굉장한 파괴력을 지니고 있다.\n지성은 높지만 성격이 난폭하고, 파괴의 극을 추구한다.", CardType.Normal, Resources.Digimon35));
            list.Add(new Card("워가루몬", 3, 1500, 1500, "[EARTH]\n이족보행으로 변한 것으로 스피드는 줄었으나 보다 민첩하고 강력한\n공격력과 방어력을 몸에 새긴 커맨드 타입의 디지몬이다.", CardType.Normal, Resources.Digimon36));
            list.Add(new Card("원뿔몬", 2, 1000, 1400, "[WATER]\n날카로운 뿔은 레어메탈의 일종인 미스릴로 이루어져 있고\n모피 아래의 가죽도 동등한 경도를 갖고 있다.", CardType.Normal, Resources.Digimon37));
            list.Add(new Card("위자몬", 2, 1200, 800, "[DARK]\n다른 차원의 디지털 월드에서 온 상급의 마인형 디지몬.\n불과 대지의 마법을 마스터해 대마도사가 되는 것을 목표로 하고 있다.", CardType.Normal, Resources.Digimon38));
            list.Add(new Card("임프몬", 1, 800, 400, "[DARK]\n악마의 아이같은 모습을 한 디지몬.\n나쁜 장난을 좋아하고 상대가 곤란에 처한 모습을 보는 것을 즐기고 있다.", CardType.Normal, Resources.Digimon39));
            list.Add(new Card("쥬드몬", 3, 1000, 1800, "[WATER]\n전과 달리 털이 다 빠진 대신 철저히 단련된 근육에 더해\n상대에게서 빼앗은 가죽이나 껍질로 만든 방어구로 감싸고 있다.", CardType.Normal, Resources.Digimon40));
            list.Add(new Card("캅테리몬", 2, 1200, 1000, "[EAUGH]\n새로 발견된 디지몬 중에서도 상당히 특이한 곤충형 디지몬\n", CardType.Normal, Resources.Digimon41));
            list.Add(new Card("케로베로스몬", 3, 1600, 1500, "[FIRE]\n지옥의 입구 부근을 배회하고 있는 케로베로스몬은 손쉽게 일을 맡는다\n", CardType.Normal, Resources.Digimon42));
            list.Add(new Card("키메라몬", 3, 1600, 1500, "[DARK]\n키메라몬의 존재는 인간이 디지털 월드에 저지른 죄악\n중에서도 금기의 영역을 어긴 것으로 탄생한 디지몬", CardType.Normal, Resources.Digimon43));
            list.Add(new Card("탱크몬", 2, 1300, 1000, "[FIRE]\n백신과 바이러스를 개의치 않고 자신에게 이득이 되는 쪽을 위해 싸운다\n", CardType.Normal, Resources.Digimon44));
            list.Add(new Card("텐타몬", 1, 700, 400, "[EAUGH]\n진화형인 다른 곤충형 디지몬은 투쟁심만을 가지고 있지만\n이 시점에서는 자연과 친하게 지내는 감정이 남아있다.", CardType.Normal, Resources.Digimon45));
            list.Add(new Card("파닥몬", 1, 600, 600, "[LIGHT]\n시속 1KM의 속도밖에 나오지 않는 탓에 걷는 쪽이 빠르다\n필사적으로 날고 있는 모습이 귀여워 인기가 많다.", CardType.Normal, Resources.Digimon46));
            list.Add(new Card("파피몬", 1, 700, 500, "[WATER]\n모피를 감싸고 있지만 훌륭한 파충류형 디지몬\n굉장히 겁이 많고 부끄럼쟁이인 성격이다", CardType.Normal, Resources.Digimon47));
            list.Add(new Card("팔몬", 1, 400, 700, "[EARTH]\n머리에 트로피컬한 꽃을 피운 식물형 디지몬", CardType.Normal, Resources.Digimon48));
            list.Add(new Card("플롯트몬", 1, 800, 500, "[LIGTH]\n늘어진 귀가 특징인 신성계 디지몬의 아이.\n아직 어린탓에 그 신성한 힘을 발휘하지 못하고 자신의 사명도 모른다.", CardType.Normal, Resources.Digimon49));
            list.Add(new Card("홀리엔젤몬", 3, 1700, 1300, "[LIGTH]\n8장의 은빛 날개를 가진 대천사형 디지몬\n홀리엔젤몬이 가진 사명은 법의 집행관이다.", CardType.Normal, Resources.Digimon50));

            return list;
        }
        public static List<Card> Load_PocketMon_Card()
        {
            List<Card> list = new List<Card>();
            list.Add(new Card("기계 사무라이", 4, 2600, 1000, "[SAMURA]\n엄청난 검술로 상대를 베어버린다.", CardType.Magic, Resources.YuGiOh4));
            list.Add(new Card("기어 골렘", 4, 1500, 2800, "[GEAR]\n거대하고 단단한 몸으로 적의 공격을 무효화 한다.", CardType.Magic, Resources.YuGiOh6));
            list.Add(new Card("기어 솔저", 4, 2500, 1800, "[GEAR]\n거대하고 단단한 총으로 적을 공격한다.", CardType.Magic, Resources.YuGiOh7));
            list.Add(new Card("마그마 드래곤", 4, 2200, 2600, "[DRAGON]\n깊은 화산에 살고 있는 드래곤이다..\n단단한 방어력을 자랑한다.", CardType.Magic, Resources.YuGiOh8));
            list.Add(new Card("맘모스", 4, 1000, 2500, "[STONE]\n단단한 방어력을 자랑하는 과거의 유산물이다.", CardType.Magic, Resources.YuGiOh9));
            list.Add(new Card("사이버 드래곤", 4, 2100, 1000, "[DRAGON]\n고도의 기술로 생산된 드래곤이다.", CardType.Magic, Resources.YuGiOh12));
            list.Add(new Card("사이버 버그", 4, 2000, 1000, "[DRAGON]\n고도의 기술로 생산된 드래곤이다.", CardType.Magic, Resources.YuGiOh13));
            list.Add(new Card("암흑기사 데몬", 4, 2300, 2300, "[DEVIL]\n지옥의 수호자이다.", CardType.Magic, Resources.YuGiOh15));
            list.Add(new Card("암흑기사 듀란달", 4, 2500, 2000, "[DARK KNIGHT]\n지옥의 수문장이다\n긴창으로 적을 사살한다.", CardType.Magic, Resources.YuGiOh16));
            list.Add(new Card("오벨리스크 거신병", 4, 3000, 1500, "[GOD]\n파괴의 지배자이다\n엄청난 공격력을 보여준다.", CardType.Magic, Resources.YuGiOh20));
            list.Add(new Card("우주기사 흑마", 4, 2500, 2000, "[KNIGHT]\n행성 파괴자이다", CardType.Magic, Resources.YuGiOh21));

            list.Add(new Card("마릴", 3, 1000, 1000, "[물페어리]\n전신의 털은 물을 튕겨내는 성질을 지녀 물을 끼얹어도 말라 있다.", CardType.Normal, Resources.PocketMoster1));
            list.Add(new Card("마릴리", 3, 1000, 1000, "[물페어리]\n전신의 털은 물을 튕겨내는 성질을 지녀 물을 끼얹어도 말라 있다.", CardType.Normal, Resources.PocketMoster2));
            list.Add(new Card("꼬지모", 3, 1100, 500, "[바위]\n옹골참, 돌머리, 주눅\n일격기를 무효화하며 체력이 가득찼을 때 일격에 쓰러지지 않는다.", CardType.Normal, Resources.PocketMoster3));
            list.Add(new Card("왕구리", 3, 1100, 800, "[물]\n전투에 나오면 5턴간 비가 내리게 된다.", CardType.Normal, Resources.PocketMoster4));
            list.Add(new Card("퉁퉁코", 3, 600, 900, "[풀]\n엽록소 리프가드 틈새포착", CardType.Normal, Resources.PocketMoster5));
            list.Add(new Card("꼬리선", 2, 400, 400, "[망보기]\n날카로운 눈을 통한 통찰, 도주", CardType.Normal, Resources.PocketMoster6));
            list.Add(new Card("노고치", 2, 400, 900, "[노말]\n야생 포켓몬에게서 반드시 도망칠 수 있다.", CardType.Normal, Resources.PocketMoster7));
            list.Add(new Card("누오", 3, 500, 1300, "[벌레비행]\n가속, 복안, 통찰", CardType.Normal, Resources.PocketMoster8));
            list.Add(new Card("니로우", 3, 1200, 400, "[악, 비행]\n이 포켓몬이 급소를 공격할 확률이 높다.", CardType.Normal, Resources.PocketMoster9));
            list.Add(new Card("다꼬리", 2, 600, 600, "[망보기]\n이 포켓몬의 명중률을 떨어뜨릴 수 없다.\n상대방의 회피율을 무시한다, 상대의 도구를 알 수 있다.", CardType.Normal, Resources.PocketMoster10));
            list.Add(new Card("대포무노", 2, 1000, 500, "[물]\n적에게 먹물을 퍼붓는다.", CardType.Normal, Resources.PocketMoster11));
            list.Add(new Card("두코", 3, 600, 900, "[풀]\n엽록소 리프가드 틈새포착", CardType.Normal, Resources.PocketMoster12));
            list.Add(new Card("딜리버드", 3, 1700, 800, "[얼음]\n수면 상태가 되지 않는다.", CardType.Normal, Resources.PocketMoster13));
            list.Add(new Card("레디바", 2, 600, 600, "[벌레비행]\n일찍 기상", CardType.Normal, Resources.PocketMoster14));
            list.Add(new Card("레디안", 2, 600, 600, "[얼음]\n수면 상태가 되지 않는다.", CardType.Normal, Resources.PocketMoster15));
            list.Add(new Card("리아코", 2, 400, 400, "[큰턱]\n우격다짐", CardType.Normal, Resources.PocketMoster16));
            list.Add(new Card("리자몽", 3, 2000, 1500, "[불꽃]\n엄청난 불꽃을 퍼붓는다. 접근하지 않는 것이 현명하다.", CardType.Normal, Resources.PocketMoster17));
            list.Add(new Card("마그케인", 1, 300, 300, "[불쥐포켓몬]\n타오르는 불꽃", CardType.Normal, Resources.PocketMoster18));
            list.Add(new Card("마자용", 3, 1800, 1200, "[에스퍼]\n서로 그림자밟기 특성일 경우 효과가 상쇄된다.", CardType.Normal, Resources.PocketMoster19));
            list.Add(new Card("만타인", 2, 900, 300, "[물]\n저수, 쓱쓱, 수의베일", CardType.Normal, Resources.PocketMoster20));
            list.Add(new Card("메가니움", 1, 300, 300, "[허브 포켓몬]\n날씨가 쾌청 상태일 때 상태이상에 걸리지 않는다.", CardType.Normal, Resources.PocketMoster21));
            list.Add(new Card("무우마", 3, 1100, 400, "[고스트]\n땅 타입 기술을 무효화한다.", CardType.Normal, Resources.PocketMoster22));
            list.Add(new Card("무장조", 3, 1900, 800, "[강철]\n명중률이 내려가지 않으며 상대의 회피율 증가를 무시한다.", CardType.Normal, Resources.PocketMoster23));
            list.Add(new Card("베이리프", 1, 300, 300, "[잎사귀 포켓몬]\n날씨가 쾌청 상태일 때 상태이상에 걸리지 않는다.", CardType.Normal, Resources.PocketMoster24));
            list.Add(new Card("부우부", 2, 600, 600, "[노말비행]\n불면, 날카로운 눈", CardType.Normal, Resources.PocketMoster25));
            list.Add(new Card("브케인", 1, 300, 300, "[불쥐포켓몬]\n타오르는 불꽃", CardType.Normal, Resources.PocketMoster26));
            list.Add(new Card("블래키", 3, 1500, 800, "[악]\n풀죽음에 영향을 받지 않는다.", CardType.Normal, Resources.PocketMoster27));
            list.Add(new Card("블레이범", 2, 400, 400, "[불쥐]\n타오르는 불꽃", CardType.Normal, Resources.PocketMoster28));
            list.Add(new Card("솜솜코", 3, 700, 1000, "[풀 비행]\n쾌청일 때 스피드가 2배로 오른다.", CardType.Normal, Resources.PocketMoster29));
            list.Add(new Card("쏘콘", 3, 800, 1900, "[벌레]\n일격기가 통하지 않으며 체력이 가득찬 상태에서 일격에 쓰러지지 않는다.", CardType.Normal, Resources.PocketMoster30));
            list.Add(new Card("아리아도스", 3, 700, 700, "[벌레독]\n불면, 벌레의 알림, 스나이퍼", CardType.Normal, Resources.PocketMoster31));
            list.Add(new Card("안농", 3, 1600, 800, "[에스퍼]\n땅 타입 기술에 맞지 않는다.", CardType.Normal, Resources.PocketMoster32));
            list.Add(new Card("야도킹", 3, 005, 1300, "[물, 에스퍼]\n혼란 상태에 빠지지 않는다.", CardType.Normal, Resources.PocketMoster33));
            list.Add(new Card("야부엉", 2, 600, 600, "[노말비행]\n불면, 날카로운 눈", CardType.Normal, Resources.PocketMoster34));
            list.Add(new Card("에브이", 3, 1300, 500, "[에스퍼]\n싱크로, 매직미러", CardType.Normal, Resources.PocketMoster35));
            list.Add(new Card("에이팜", 3, 1200, 700, "[노말]\n픽업, 도주, 스킬링크", CardType.Normal, Resources.PocketMoster36));
            list.Add(new Card("엘리게이", 2, 400, 400, "[큰턱]\n우격다짐", CardType.Normal, Resources.PocketMoster37));
            list.Add(new Card("왕자리", 3, 1200, 500, "[벌레비행]\n가속, 복안, 통찰", CardType.Normal, Resources.PocketMoster38));
            list.Add(new Card("우파", 3, 300, 1100, "[벌레비행]\n가속, 복안, 통찰", CardType.Normal, Resources.PocketMoster39));
            list.Add(new Card("잠만보", 3, 1500, 2000, "[푸근]\n독, 맹독 상태가 되지 않는다.", CardType.Normal, Resources.PocketMoster40));
            list.Add(new Card("장크로다일", 2, 400, 400, "[큰턱]\n우격다짐", CardType.Normal, Resources.PocketMoster41));
            list.Add(new Card("총어", 2, 700, 400, "[물]\n의욕, 스나이퍼, 벽던쟁이", CardType.Normal, Resources.PocketMoster42));
            list.Add(new Card("치코리타", 1, 300, 300, "[잎사귀]\n날씨가 쾌청 상태일 때 상태이상에 걸리지 않는다.", CardType.Normal, Resources.PocketMoster43));
            list.Add(new Card("코산호", 3, 800, 1500, "[물]\n귀여워서 공격하기 두렵다.", CardType.Normal, Resources.PocketMoster44));
            list.Add(new Card("키링키", 3, 700, 1500, "[노말, 에스퍼]\n풀죽지 않는다.", CardType.Normal, Resources.PocketMoster45));
            list.Add(new Card("토게틱", 3, 800, 800, "[페어리비행]\n의욕, 하늘의은총, 대운", CardType.Normal, Resources.PocketMoster46));
            list.Add(new Card("페이검", 3, 700, 700, "[벌레독]\n불면, 벌레의알림, 스나이퍼", CardType.Normal, Resources.PocketMoster47));
            list.Add(new Card("피콘", 3, 700, 1800, "[벌레]\n옹골참, 방진", CardType.Normal, Resources.PocketMoster48));
            list.Add(new Card("해너츠", 3, 600, 1200, "[풀]\n엽록소, 선파워, 일찍기상", CardType.Normal, Resources.PocketMoster49));
            list.Add(new Card("해루미", 3, 800, 1300, "[풀]\n잠듦 상태가 되었을 때, 잠드는 턴이 절반으로 줄어든다.", CardType.Normal, Resources.PocketMoster50));

            return list;
        }

        public static List<Card> Load_YuGiOh_Card()
        {
            List<Card> list = new List<Card>();
            list.Add(new Card("기계 사무라이", 4, 2600, 1000, "[SAMURA]\n엄청난 검술로 상대를 베어버린다.", CardType.Magic, Resources.YuGiOh4));
            list.Add(new Card("기어 골렘", 4, 1500, 2800, "[GEAR]\n거대하고 단단한 몸으로 적의 공격을 무효화 한다.", CardType.Magic, Resources.YuGiOh6));
            list.Add(new Card("기어 솔저", 4, 2500, 1800, "[GEAR]\n거대하고 단단한 총으로 적을 공격한다.", CardType.Magic, Resources.YuGiOh7));
            list.Add(new Card("마그마 드래곤", 4, 2200, 2600, "[DRAGON]\n깊은 화산에 살고 있는 드래곤이다..\n단단한 방어력을 자랑한다.", CardType.Magic, Resources.YuGiOh8));
            list.Add(new Card("맘모스", 4, 1000, 2500, "[STONE]\n단단한 방어력을 자랑하는 과거의 유산물이다.", CardType.Magic, Resources.YuGiOh9));
            list.Add(new Card("사이버 드래곤", 4, 2100, 1000, "[DRAGON]\n고도의 기술로 생산된 드래곤이다.", CardType.Magic, Resources.YuGiOh12));
            list.Add(new Card("사이버 버그", 4, 2000, 1000, "[DRAGON]\n고도의 기술로 생산된 드래곤이다.", CardType.Magic, Resources.YuGiOh13));
            list.Add(new Card("암흑기사 데몬", 4, 2300, 2300, "[DEVIL]\n지옥의 수호자이다.", CardType.Magic, Resources.YuGiOh15));
            list.Add(new Card("암흑기사 듀란달", 4, 2500, 2000, "[DARK KNIGHT]\n지옥의 수문장이다\n긴창으로 적을 사살한다.", CardType.Magic, Resources.YuGiOh16));
            list.Add(new Card("오벨리스크 거신병", 4, 3000, 1500, "[GOD]\n파괴의 지배자이다\n엄청난 공격력을 보여준다.", CardType.Magic, Resources.YuGiOh20));
            list.Add(new Card("우주기사 흑마", 4, 2500, 2000, "[KNIGHT]\n행성 파괴자이다", CardType.Magic, Resources.YuGiOh21));
            return list;
        }

        public static List<Card> Load_YuGiOh_Card_F()
        {
            List<Card> list = new List<Card>();
            list.Add(new Card("가이아의 검사", 4, 2500, 1000, "[KNIGHT]\n성스러운 검으로 적을 베어버린다\n필드 소환 시 적 카드 1개를 베어버린다.", CardType.Magic, Resources.YuGiOh1, "destroy")); //적 카드 한 장 파괴
            list.Add(new Card("스페이스 데몬", 4, 2500, 2000, "[DRAGON]\n우주의 지배자이다.\n소환 시 적팀 카드 한장을 파괴한다.", CardType.Magic, Resources.YuGiOh14, "destroy"));  //적 카드 한 장 파괴
            list.Add(new Card("얼티밋 데몬", 4, 2600, 2000, "[DEMON]\n데몬의 지배자이다.\n소환 시 적의 카드를 하나 파괴한다.", CardType.Magic, Resources.YuGiOh17, "destroy"));    //적 카드 한 장 파괴
            list.Add(new Card("트윈 드래곤", 4, 2500, 1000, "[DRAGON]\n두마리 용의 합체형이다. \n소환 시 적의 카드를 파괴한다.", CardType.Magic, Resources.YuGiOh23, "destroy"));  //적 카드 한 장 파괴
            list.Add(new Card("골드 드래곤", 4, 1000, 2800, "[DRAGON]\n금색의 단단한 드래곤이다.\n소환 시 카드 한장을 드로우한다.", CardType.Magic, Resources.YuGiOh2, "draw"));    // 카드 한 장 드로우
            list.Add(new Card("기아의 가이아", 4, 2200, 2000, "[KNIGHT]\n긴창으로 적을 관통한다.\n필드 소환시 카드 한장을 드로우 한다.", CardType.Magic, Resources.YuGiOh5, "draw"));  //카드 한 장 드로우
            list.Add(new Card("블루 스피더", 4, 2200, 1500, "[TUTELAR]\n숲의 수호자이다.\n소환 시 카드 한장을 드로우한다.", CardType.Magic, Resources.YuGiOh11, "draw"));    //카드 한 장 드로우
            list.Add(new Card("그린 박사", 4, 2200, 1500, "[DOCTOR]\n괴상한 기술로 상대를 공격한다.\n소환 시 적의 1턴을 뺏는다.", CardType.Magic, Resources.YuGiOh3, "skip")); //점프 턴
            list.Add(new Card("얼티밋 드래곤", 4, 2400, 1500, "[DRAGON]\n공간의 지배자이다.\n소환 시 적의 라이프 500을 차감한다.", CardType.Magic, Resources.YuGiOh18, "attack")); //상대방 본체 공격
            list.Add(new Card("붉은 눈의 흑룡", 4, 2500, 2000, "[DRAGON]\n한때 세상을 지배한 용이다.\n소환 시 필드에 카드 하나를 추가로 소환한다.", CardType.Magic, Resources.YuGiOh10, "summon"));   //카드 한 장더 필드 소환
            list.Add(new Card("엘리멘탈 히어로", 4, 2500, 1800, "[ANGEL]\n한때 천상을 지배하던 자이다.\n소환 시 라이프 500을 회복한다.", CardType.Magic, Resources.YuGiOh19, "heal"));    //플레이어 생명력 회복
            list.Add(new Card("천상 검사", 4, 2600, 1800, "[ANGEL]\n천상의 검술을 사용하는 대천사이다\n소환 시 라이프 500을 회복한다.", CardType.Magic, Resources.YuGiOh22, "heal"));     //플레이어 생명력 회복
            return list;
        }
        public static List<Card> Load_YuGiOh_SpecialCard()
        {
            List<Card> list = new List<Card>();
            list.Add(new Card("얼티밋 레인보우 드래곤\n3000POINT", 5, 4500, 4500, "[GOD]\n날씨를 관장하는 신이다.\n소환시 라이프 1000을 회복한다", CardType.Magic, Resources.YuGiOhSpecial1, "heal"));
            list.Add(new Card("오르킨 골드아이드래곤\n3500POINT", 5, 4000, 5000, "[GOD]\n행성을 창조하는 신이다.\n소환시 라이프 1000을 회복한다.", CardType.Magic, Resources.YuGiOhSpecial2, "heal"));
            list.Add(new Card("얼티밋 붉은눈의 흑룡\n2500POINT", 5, 4500, 4000, "[GOD]\n파고의 본능만이 남은 용의 신이다.\n소환시 적의 모든 공격카드를 파괴한다.", CardType.Magic, Resources.YuGiOhSpecial3, "destroy"));
            list.Add(new Card("얼티밋 푸른눈의 백룡\n2000POINT", 5, 4500, 3500, "[GOD]\n한때 용들의 신이었다.\n소환시 라이프 1000을 회복", CardType.Magic, Resources.YuGiOhSpecial4, "heal"));
            list.Add(new Card("다크 팔라딘\n2000POINT", 5, 4500, 3500, "[GOD]\n검과 마법의 융합으로 나라 하나를 삼킨다.\n소환시 라이프 1000을 회복.", CardType.Magic, Resources.YuGiOhSpecial5, "heal"));
            list.Add(new Card("오시리스의 천공룡\n3000POINT", 5, 5000, 4000, "[GOD]\n브레스 한번으로 나라 하나가 파괴 할 수 있는 힘을 가진 신이다.\n소환시 적팀에게 1000의 피해를 준다.", CardType.Magic, Resources.YuGiOhSpecial6, "attack"));
            list.Add(new Card("오벨리스크의 거신병\n4500POINT", 5, 5000, 4500, "[GOD]\n손하나로 모든걸 파괴할 수 있는 힘을 가진 신이다.\n소환시 적팀 수비카드 모두를 파괴한다.", CardType.Magic, Resources.YuGiOhSpecial7, "destroy"));
            list.Add(new Card("소환신 엑조디아\n4500POINT", 5, 5000, 4500, "[GOD]\n모든걸 파괴할 수 있는 힘을 가진 신이다.\n소환시 적팀 공격카드 모두를 파괴한다.", CardType.Magic, Resources.YuGiOhSpecial8, "destroy"));
            list.Add(new Card("함정카드\n10000POINT", 12, 9999, 9999, "[GOD]\n신이다.\n소환시 게임을 승리한다.", CardType.Magic, Resources.YuGiOhSpecial9, "win"));
            list.Add(new Card("라의 익신룡\n3000POINT", 5, 5000, 4000, "[GOD]\n낙뢰한번으로 나라 하나가 파괴 할 수 있는 힘을 가진 신이다.\n적팀에게 1000의 피해를 준다.", CardType.Magic, Resources.YuGiOhSpecial10, "attack"));
            list.Add(new Card("프로바이어스", 4, 9999, 0, "[BOMB]\n엄청난 폭발력을 가진다.\n공격시 카드도 같이 폭발한다.", CardType.Magic, Resources.YuGiOh24));

            return list;
        }
        public string TooltipInfo()
        {
            return $"이름: {Name}\n랭크: {Rank}\n공격력: {Attack}\n수비력: {Defense}\n정보: {CardInfo}";
        }
    }
}
