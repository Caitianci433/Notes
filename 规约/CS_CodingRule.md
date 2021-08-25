## 概要

------

### 前提事項

- 本システムのコーディングに用いる C# のバージョンは、8.0 とする
- 本書は、Microsoft より発行されている「C# のコーディング規則 (C# プログラミング ガイド)」をベースにカスタマイズした規約となる。
- 命名等は、CS_命名規約を参照とのこととする。

### 本規約制定の目的

本規定は、以下の効果を狙い制定する

- コードの見た目を統一し、コードを読むときに、レイアウトではなく内容に重点が置かれる
- 経験に基づく推測が働くことにより、より迅速なコード理解に寄与する
- コードのコピー、変更、および保守を容易にする
- 本規約により、C# のコーディングのベストプラクティスの理解を促進する

### 重要度合の説明

本規約にでは、必須のものと推奨ものを以下のように定義することとする。 |★|対応必須有無|説明 |:--|:--|:--| |★1|必須|静的ツールにて対応| |★2|必須|レビューアによるレビューにて対応| |◎|推奨事項|ガイドライン的な扱い。全て満たしているかのチェックは行わない）| |〇|任意|ガイドライン的な扱い。全て満たしているかのチェックは行わない）|

## 変数・定数等

------

### [★2]メンバ変数は、必ずprivateにする。

- 外部には、直接公開させず公開する場合は、プロパティを設ける

```cs
//Bad Code
public class Person{
    public string Name;
}
//Good Code
//Get/Set
public class Person{
    public string Name{ get; set; }
}

//Getのみ
public class Person{
    private string _Name;
    public string Name{ get {return _Name; } } 
}

//Getのみ
public class Person{
    public string Name{ get ; private set; } } 
}
```

### [★2]ローカル変数のスコープは短くし、使い回しをしない

1. NG : メソッドの先頭で全ての変数を定義

2. NG : ローカル変数を宣言する場所と使用する場所が離れている

   > 変数は、使用する直前で定義する。

3. NG : 定義済みの変数を、使用目的を変え再利用

   > 変数は、最初に設定した値以外の値を入れる場合、別の変数を定義する。

   ```cs
   //Bad Code
   public class BadSample
   {
     public void Sample()
     {
       //1. NG : メソッドの先頭で全ての変数を定義
       //2. NG : ローカル変数を宣言する場所と使用する場所が離れている
       var localValue1 = 10;
       var localValue2 = 20;
       var localValue3 = 30;
   
       TestClass test = new TestClass();
   
       test.sampleMethod1(localValue1);
   
       test.sampleMethod2(localValue2);
   
       test.sampleMethod3(localValue3);
   
       var value = localValue1 + localValue2 + localValue3
       Console.WriteLine($"合計:{value}");
   
       //3. NG : 定義済みの変数を、使用目的を変え再利用する
       value = value / 3
       Console.WriteLine($"平均:{value}");
   
     }
   } 
   
   //Good Code
   public class FixedSample
   {
     public void Sample()
     {
       TestClass test = new TestClass();
   
       var localValue1 = 10;
       test.sampleMethod1(localValue1);
   
       var localValue2 = 20;
       test.sampleMethod2(localValue2);
   
       var localValue3 = 30;
       test.sampleMethod3(localValue3);
   
       var summery = localValue1 + localValue2 + localValue3
       Console.WriteLine($"合計:{summery}");
   
       var average = summery / 3
       Console.WriteLine($"平均:{average}");
   
     }
   }
   ```

### [★2]staticなメンバ変数は、原則使用禁止とする

- Staticなメンバ変数は、どこからも参照変更可となり且つシングルトンとなる。

- それにより、不具合の誘発性が高まるとともに、可読性や生産性も下がるため、原則使用しない。

  > 使用する場合は、基盤Tに連携・検討の上、採用可否を判断とする。

### [★2]マジック・ナンバーとなる数値表現での記述は禁止とする

- マジック・ナンバーは、その数値を見ただけでは、意味が読取ずらくなるため、使用しない。

- マジックナンバーとなりえる部分は、メソッド内ローカルにおいても定数等を定義する。

  ```cs
  //Bad Code
  // マジック・ナンバーとなる数値表現
  double calculateTaxIncludedPrice(double price) {
      return 1.1 * price;
  }
  
  //Good Code
  // マジック・ナンバーとならない数値表現
  double calculateTaxIncludedPrice(double price) {
      const double TaxRate = 0.1;
      return price + (price * TaxRate);
  }
  ```

  > ただし、変数名等文脈から理解可能な場合は、例外とする。

  ```cs
  var milliSec = sec * 1000; //ミリ秒を算出しているの旨は、文脈から把握可能
  ```

### [◎]暗黙的に型指定されるローカル変数

- 変数の型が割り当ての右側から明らかである場合、または厳密な型が重要でない場合は、ローカル変数の暗黙の型指定:**var**を使用する

  ```cs
  var message = "This is clearly a string.";
  var age = 27;
  var inputValue = Convert.ToInt32(Console.ReadLine());
  ```

- 割り当ての右側から型が明らかではない場合、var を使用しない

  > 極力このようなことが起きないよう、メソッド等の戻り値等は、わかりやすくすること

  ```cs
  int count = ExampleClass.ResultSoFar();
  ```

## 条件分岐

------

### [◎]比較演算子は、左を小、右を大として、原則<、<=のみ使用する

- 可同性向上のため、統一とする。

  ```cs
  //Bad Code
  if ((age >= 90 && a <= 180) || (a >= 270 && a <= 360))
  //Good Code
  if ((90 <= a && a <= 180) || (270 <= a && a <= 360))
  ```

### [★2]分岐条件は、原則肯定形とする。

- 条件分岐において、原則、肯定形とする。

- else句がない、否定の時のみの処理を行う場合は、OKとする。

  ```cs
  //Bad Code
  if(!IsOver){
    //
  }else{
  
  }
  //Good Code
  if(IsOver){
    //
  }else{
  
  }
  
  //こちらは、OK
  if(!IsOver){
    //else句がない、否定の時のみの
  }
  ```

- メソッド名および変数名は肯定形で記述し、2重否定のロジックにしない。

  ```cs
  //Bad code
  // 二重否定
  if (!isNotFound)
  if (!IsNotNull())
  
  //Good code
  // 肯定形
  if (Exists())
  if (Contains())
  ```

### [〇]Enumや定数によるif/switch分岐を行う場合、IDictionaryを検討する。

- Enum,定数等によるif/switch分岐によって値設定や呼び出すメソッドを変える際、IDictionaryを使用することで、ネスト構造や分岐の追加が容易にしやすくなる。

  > メソッドの場合は、呼び出すメソッドの戻り値/引数をそろえる必要がある。

  ```cs
  //Bad Code
  public void Sample(Position position){
    var baseSalary = 0;
    if(position == Position.Director){
      baseSalary = 500000
    }else if(position == Position.Manager){
      baseSalary = 400000
    }else if(position == Position.Leader){
      baseSalary = 300000
  
    }else if(position == Position.SubLeader){
      baseSalary = 250000
    }else{
      baseSalary　= 200000;
    }
  }
  //Bad Code
  public void Sample(Position position){
    var positionBaseSalarys = new Dictionary(){
      {Position.Director,500000},
      {Position.Manager,400000},
      {Position.Leader,300000},
      {Position.SubLeader,250000},
    }
    var nonPositionalary = 2000000;
    return positionBaseSalarys.ContainsKey(position) ?
          positionBaseSalarys[baseSalarys] : nonPositionalary;
  }
  ```

- 分岐を使用する場合、どれにも一致しない場合最終句のelseではなく、分岐の初期値として保持する。

  ```cs
  //BadCode
  public void Sample(Position position){
    var baseSalary = 0; 
    if(position == Position.Director){
      baseSalary = 500000
    }else if(position == Position.Manager){
      baseSalary = 400000
    }else if(position == Position.Leader){
      baseSalary = 300000
    }else if(position == Position.SubLeader){
      baseSalary = 250000
    }else{
      baseSalary　= 200000;//Else句ないで設定はせず、初期値にする。
    }
  }
  
  //GoodCode
  public void Sample(Position position){
    var baseSalary = 200000; //Else句ないで設定はせず、初期値にする。
    if(position == Position.Director){
      baseSalary = 500000
    }else if(position == Position.Manager){
      baseSalary = 400000
    }else if(position == Position.Leader){
      baseSalary = 300000
    }else if(position == Position.SubLeader){
      baseSalary = 250000
    }
  }
  ```

### [★2]条件分岐などでの&&演算子および||演算子を使用する。

- パフォーマンスを向上させるには、比較を実行する場合、次の例に示すように & の代わりに && を、| の代わりに || を使用する

  ```cs
  //Bad Code
  if(22<=age & age <= 60 )
  {
  
  }
  //Good Code
  if(22<=age && age <= 60 )
  {
  
  }
  ```

## メソッド

------

### [★2]ネストは2階層までとする

- それ以上深くなる場合は、メソッド化、設計の見直し等を考える。

### [★2]3重以上のループは禁止とする

- 3重以上深くなる場合は、ラムダ式、メソッド化、設計の見直し等を考える。

### [★2]ガード節を有効にし、早期のReturnを行う実装にする。

- ネストが深くなるの避け可読性向上のため、returnは、メソッドの早い段階で行う。

- 最後に一括Retunは、可読性低下につながる。

- 必ず実行したい処理がある場合は、Try-Finallyで行う。

  ```cs
  //Bad Code
  public bool ExceuteProcess(Huamn human){
      if(human.TryInitilize()){
          var result = false;
          if(human.HasProcessAuthrity){
              if(human.IsAdministrator){
                result = ExecuteAdministrator()
              }else if(human.IsEnginner){
                result = ExecuteEnginner()
              }else if(human.IsOperator){
                result = ExecuteOperator()
              }else{
                result = false;
              }
              return result;
          }else{
              return false;
          }
      }else{
          return false;
      }
  }
  //Good Code
  public bool ExceuteProcess(Huamn human){
      if(!human.TryInitilize()){ //即returnする。この場合の否定は、問題なし
          return false;
      }
      if(!human.HasProcessAuthrity){//即returnする。この場合の否定は、問題なし
          return false;
      }
      if(human.IsAdministrator){
          return ExecuteAdministrator();//即returnする。
      }
      if(human.IsEnginner){
          return ExecuteEnginner();//即returnする。
      }
      if(human.IsOperator){
          return ExecuteOperator();//即returnする。
      }
      return false;
  }
  ```

## 配列

### [◎]配列系の戻り値では、nullをreturnしない。

- 配列やCollectionを返却するメソッドにて、要素が0の場合、nullではなく空の配列/空のCollectionをreturnする。

### [★2]Collection型を引数、戻り値、変数の型等に指定する場合、インタフェースなどの抽象型を指定する。

- ArrayList ,Dictionary<string,int> ではなく、**I**List,**I**Dictionary<string,int>を使用する。

  

  ```cs
  //Bad Code
  public ArrayList<string> ToListOfKeys(Dictionary<string,int> samples){
      ArrayList<string> list = new ArrayList<string>();
  }
  //Good Code
  public IList<string> ToListOfKeys(IDictionary<string,int> samples){
      IList<string> list = new ArrayList<string>();
  }
  ```

## 型について

------

### [★2]unsigned型は使わない

- uintではなく、intを使用します。

### [★2]プリミティブ型/CLS型が存在する方は、プリミティブ型に統一する。

- int,string,objct等では、プリミティブ型とCLS型の2種類が存在するが、混在を避けるためプリミティブ型を使用する。

| プリミティブ型 | CLS型  |
| :------------- | :----- |
| int            | Int32  |
| string         | String |
| object         | Object |

> 他のdecimal、Decimal等でも上記と同じとする。

## オブジェクトの生成

### [★2]DIContainer対象のオブジェクトについては、newをせず、DIContainerから取得する。

- その際コンストラクターにてDIContenerから型をインタフェースにて取得し、readonleyのメンバ変数に設定する。

```cs
public class Sample{
    private readonley ILogger<Sample> _Logger;
    public Sample(ILogger<Sample> logger){
      _Logger　= logger;
    }
}
```

### [◎]DI対象外オブジェクトは、型をvarにてインスタンス化する。

- 次の宣言に示すように、暗黙の型指定(**var**)を使用してオブジェクトのインスタンス化を簡潔な形式にする

```cs
var instance1 = new ExampleClass();
```

前の行は次の宣言に相当する

```cs
ExampleClass instance2 = new ExampleClass();
```

### [◎]オブジェクト初期化子を使用してオブジェクトの作成を簡略化する

```cs
var instance3 = new ExampleClass { Name = "Desktop", ID = 37414,
    Location = "Redmond", Age = 2.3 };
```

## 例外処理

------

### [★2]例外処理は、安易には行わない。

- Try-Catch句は、必要な場合のみ記載し、闇雲に行わない。

  > 例外をキャッチして処理する場合のみ、キャッチとする。

- 例外をキャッチ後、呼び出し元に例外をスローする場合、以下とする。

  - 呼び出し元にこれまでの例外詳細情報を伝える場合

    - throwのみとする

      ```cs
      try{
      
      }catch(FileNotFoundException ex){
          throw
      }
      ```

  - 呼び出し元にこれまでの例外詳細情報を伝えない場合

    - throw exとする

      ```cs
      try{
      
      }catch(FileNotFoundException ex){
          throw ex
      }
      ```

## その他

------

### [★2]キャストする場合は、asを使用する。

- レスポンス向上のため、キャストを行う場合、(型)やisではなく**as**を使用する。

  ```cs
  //Bad code
  var employee = (Employee)obj;
  var employee = obj is Employee;
  
  //Good Code
  var employee = obj as Employee;
  ```

### [★2]文字列型(String)の操作

- 短い文字列を連結するときは文字列補間「$」を使用する

  ```cs
  string displayName = $"{nameList[n].LastName}, {nameList[n].FirstName}";
  ```

- ループ内で文字列を追加する場合 (特に大量のテキストを処理する場合) は、StringBuilder オブジェクトを使用する

  ```cs
  var phrase = "lalalalalalalalalalalalalalalalalalalalalalalalalalalalalala";
  var manyPhrases = new StringBuilder();
  for (var i = 0; i < 10000; i++)
  {
      manyPhrases.Append(phrase);
  }
  ```

### [◎]readonlyとconst

- 定数の場合は、constを使用する。

- リストやオブジェクトなどをメンバ変数に持つ場合、原則、readonlyとする。

  > オブジェクト生成時から変えないようにすることで、可読性が向上する。

### [◎]三項演算子の使用

- 使用することは問題なし。
- ただし、三項演算子にすることで、可読性が下がる場合は、if文等に変えること。

### [◎]null合体演算子、条件演算子

- オブジェクトのnullチェックとして、合体演算子「??」や条件演算子「?.」を使用する。

  ```cs
  User user = TryGetUser(id) ?? DefaultUser();
  ```

  ```cs
  var name = user?.Name;
  //以下と同じ
  string name;
  if (user != null) name = user.Name;
  ```

### [★2]IDisposeインタフェースを実装したクラスは、Usingを使用し処理をする。

- Fileなどリソースにアクセスするクラスは、IDisposeインタフェースを実装したクラスほとんどである。

- **その際は、usingを使用し処理を行い、必ずDispose処理が走るようにする。**

- その際、C#8.0以降では、「{}」が不要となったため「{}」は記載しないこととする。

  ```cs
  //C#8.0
  using var stream = new MemoryStream(data)
  
  //C#7.0以前
  using (var stream = new MemoryStream(data)){
  
  }
  ```

### [◎]ラムダ式の使用

- ループより、Linqやラムダ式を使用する

- Linqやラムダ式以外で、ループを行う場合、forよりfoeachを使用する

  ```cs
  // Bad Code
  var evenMax = 0;
  foreach (var d in decimals)
  {
      if (d % 2 == 0)
      {
          if (d > evenMax)
          {
              evenMax = d;
          }
      }
  }
  
  // Good Code : LINQ(メソッド構文 + ラムダ式)
  var oddMin = decimals
      .Where(x => (x % 2) == 1)
      .Min();
  
  // Good Code : LINQ(クエリ構文)
  var averageAgeOfMan = (
      from person in persons
      where (person.Sex == Sex.Man)
      select person.Age).Average();
  ```

## [◎]LINQ クエリ

- クエリ変数にはわかりやすい名前を使用する

  ```cs
  var seattleCustomers = from customer in customers
                         where customer.City == "Seattle"
                         select customer.Name;
  ```

- エイリアスを使用して、匿名型のプロパティ名の大文字と小文字の使用が正しい Pascal 形式になるようにする

  ```cs
  var localDistributors =
      from customer in customers
      join distributor in distributors on customer.City equals distributor.City
      select new { Customer = customer, Distributor = distributor };
  ```

- 結果のプロパティ名があいまいになる場合は、プロパティ名を変更する。 たとえば、クエリで顧客名と販売店 ID を返す場合、クエリ結果で Name と ID をそのまま使用するのではなく、これらの名前を変更し、Name が顧客の名前であり、ID が販売店の ID であることを明確にする。

  ```cs
  var localDistributors2 =
      from customer in customers
      join distributor in distributors on customer.City equals distributor.City
      select new { CustomerName = customer.Name, DistributorID = distributor.ID };
  ```

- クエリ変数と範囲変数の宣言で暗黙の型指定を使用する

  ```cs
  var seattleCustomers = from customer in customers
                         where customer.City == "Seattle"
                         select customer.Name;
  ```

- 前の例に示すように、クエリ句を from 句の下に配置する

- where 句を他のクエリ句より先に使用し、それ以降のクエリ句では、フィルター化されたデータセットが処理されるようにする

  ```cs
  var seattleCustomers2 = from customer in customers
                          where customer.City == "Seattle"
                          orderby customer.Name
                          select customer;
  ```

- 内部コレクションにアクセスするには、fromjoin 句ではなく複数の 句を使用する。 たとえば、Student オブジェクトのコレクションがあり、各オブジェクトに試験の点数のコレクションが含まれているとすると、次のクエリを実行すると、90 点より高い点数とその点数を取った学生の姓が返却される。

  ```cs
  var scoreQuery = from student in students
                   from score in student.Scores
                   where score > 90
                   select new { Last = student.LastName, score };
  ```

## 補足：プログラミング原則・格言

引用元：https://qiita.com/Ted-HM/items/67eddbe36b88bf2d441d

- 今回、規約やAP基盤の開発時に指針としている格言等になります。「★」となります。

### ★DRY

- DRY(Don't repeat yourself)とは、アプリケーションに必要な情報は、重複を避けるべきという考え方です。
  - 重複があると変更漏れや作業量、コード量の増大につながります。
  - DRY原則に反しているシステムをWET(Write Every Time)なシステムと呼びます。

### ★OAOO

- OAOO(Once and only once)とは、コードの機能、ふるまいの重複を避けるべきという考え方です。

### ★KISS

- KISS(Keep it simple, stupid)とは、簡潔にせよという考え方です。
  - 不必要な複雑性は避けるべきです。

### ★YAGNI

- YAGNI(You aren't gonna need it)とは、無駄をなくすための考え方です。
  - シンプルに作成し、必要になったときに実装するべきです。

### SDP

- 安定依存の原則(SDP: Stable-dependencies principle)とは、パッケージ間の依存関係の指針です。
  - 変更が少なく被参照が多い安定したパッケージが、変更が多い不安定なパッケージに依存してはいけません。
  - OCPやDIPに従い抽象化することによりSDPに則した構造となります。

### SOLID

- SRP, OCP, LSP, ISP, DIPの頭文字からSOLIDとまとめて呼ばれます。

> https://postd.cc/solid-principles-every-developer-should-know/

#### SRP★

- 単一責任の原則(SRP: Single responsibility principle)とは、クラスの変更理由はひとつでなければならないという考え方です。
  - 責任という観点で見ることが重要です。

#### OCP

- オープン・クローズドの原則(OCP: Open/closed principle)とは、拡張に対して開いていて、修正に対して閉じていなければならないという考え方です。
- 抽象化を行い、継承していくことで機能の拡張ができます。
- 抽象化しておくと、実装を差し替えるだけでインターフェイスには影響を与えません。
- 抽象化は柔軟性と複雑性のトレードオフとなります。

#### LSP

- リスコフの置換原則(LSP: Liskov substitution principle)とは、スーパークラスとサブクラスは置換できなければならないという考え方です。
- サブクラスでオーバーライドされた結果、動作が意図しないものに変わってしまってはいけません。

#### ISP★

- インターフェイス分離の原則(ISP: Interface segregation principle)とは、インターフェイスをシンプルに保つための指針です。
- 複数のクライアントにおいて、片方のクライアントから参照しないメソッドがある場合は、インターフェースを分離します。

#### DIP★

- 依存関係逆転の原則(DIP: Dependency inversion principle)とは、依存関係を切り離す抽象化の手法です。
- 上位のクラスは下位のクラスに依存するべきではなく、どちらもインターフェイスに依存させます。

### PIE★

- PIE(Program intently and expressively)とは、意図を明確に表現するコードを書くということです。
- 書きやすさより読みやすさを重視します。

### SLA, SLAP

- SLA(Single level of abstraction principle)とは、抽象化レベルを揃えるという考え方です。

### PLS, PLA, POLA

- 驚き最小の原則(PLS: Principle of least surprise)とは、最も自然に思えるものを選択すべきだとする考え方です。

### ループバックチェック

- 名前可逆性という命名に関する指針があります。
- 名前は、そのもととなった内容の説明文を復元できなければならないということです。

### 行ってはならない★

- パフォーマンスチューニング、最適化に関する2つの格言です。
  - 行ってはならない(Don't do it.)
  - まだ行ってはならない(Don't do it yet.)
  - 早すぎる最適化は、無駄になるだけでなく、コードを複雑にしてしまいます。

### 求めるな、命じよ★

- 求めるな、命じよ(TdA: Tell, don't ask.)とは、オブジェクト指向の設計指針です。
  - 手続き型では、情報を取得して自分で処理をします。
  - オブジェクト型では、オブジェクトに処理を命じます。

### デメテルの法則★

- デメテルの法則(LoD: Law of Demeter)とは、依存関係を排除する指針となります。
  - 最小知識の原則(PLK: Principle of least knowledge)や知らないヤツには話しかけない(Don't talk to strangers.)とも呼ばれます。
  - オブジェクト自身、オブジェクトに渡されたインスタンス、オブジェクト内部で生成したインスタンス以外には依存してはいけません。
  - 例えば「あるインスタンス」から「別クラスのインスタンス」を取得した場合、「別クラス」への依存関係が発生してしまいます。

### オペランドの原則★

- メソッドの引数にはオペランドのみを指定するべきという指針です。
  - この原則に従うとオプションを追加してもインターフェイスを変更する必要がありません。

### 割れた窓の法則

- 割れ窓理論をソフトウェア開発に当てはめた言葉です。
  - コードが清潔で美しく保たれている場合、開発者はソレを汚さないよう細心の注意を払うことになります。

### ボーイスカウト・ルール

- ボーイスカウトには「自分のいた場所は、そこを出ていくときは、来た時よりもキレイにしなければならない」というルールがあります。
  - 小さな洗練を継続させることで、コードがよりよい方向へ向かっていきます。

### UNIX哲学

- UNIXの設計哲学です。 「1. Small is beautiful.」から始まる19の定理からなります。