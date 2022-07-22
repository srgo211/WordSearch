using System.Text.RegularExpressions;

Console.WriteLine("Старт!\n");

int maxWord = 6;       //макс. число слов для поиска
int curentSumWord = 0;

//имитация данных из БД
List<Content> contents = new()
{
	new Content() { Id = 0, Text = "Заболела жена программиста. Чихает, насморк у нее. Звонит ее подруга. Трубку берёт муж: - Сергей, привет. Как себя Ира чувствует? - Изображение неплохое, а вот звук неважный.  © https://anekdoty.ru/pro-programmistov/" },
	new Content() { Id = 1, Text = "Разнообразный" },
	new Content() { Id = 2, Text = "и богатый" },
	new Content() { Id = 3, Text = "опыт реализация намеченных" },
	new Content() { Id = 4, Text = "плановых заданий позволяет выполнять" },
	new Content() { Id = 5, Text = "важные задания по разработке модели" },
	new Content() { Id = 6, Text = "развития." },
};


//получаем объект из ID и кол-во слов в тексте
var objCountWord = contents
   .Select(s => new
   {
	   Id = s.Id,
	   CountWords = Regex.Matches(s.Text, "\\w+").Count
   }).ToList();


List<int> idList = new(); //получаем ID
foreach (var obj in objCountWord)
{
	if (obj.CountWords > maxWord) continue;
	
	curentSumWord += obj.CountWords;

	if (curentSumWord <= maxWord)
	{
		idList.Add(obj.Id);
	}
}

List<Content> result = new(); //данные с результатом
foreach (var id in idList)
{
	var content = contents.FirstOrDefault(x=>x.Id == id);

	if (content == null) continue;

	result.Add(content);
}

Console.WriteLine($"Результат: макс. число слов {maxWord} в моделях:\n" +
				$"{String.Join("\n", result)}"); 



#region Models
public class Content
{

	public int Id { get; set; }
	public string Text { get; set; }
    public override string ToString()
    {
        return $"[{Id}] {Text}";
    }

}
#endregion