using System.Collections.Generic;
using System.Diagnostics;

namespace _4_quiz_app
{
    public class Quiz
    {
        private List<Question> questions;
        private int correctAnswersCount;
        private Stopwatch stopwatch;

        public Quiz()
        {
            questions = new List<Question>();
            correctAnswersCount = 0;
            stopwatch = new Stopwatch();
            InitializeQuestions();
        }

        private void InitializeQuestions()
        {
            questions.Add(new Question(1, "Какой модификатор доступа позволяет обращаться к члену класса только внутри самого класса?",
                new[] { "public", "private", "protected", "internal" }, 2));
            questions.Add(new Question(2, "Какой метод используется для преобразования строки в число типа double?",
                new[] { "Convert.ToInt32", "double.Parse", "int.Parse", "string.ToDouble" }, 2));
            questions.Add(new Question(3, "Что возвращает оператор 'is' в C#?",
                new[] { "Число", "Строку", "Булевое значение", "Объект" }, 3));
            questions.Add(new Question(4, "Какой класс используется для работы с массивами переменной длины в C#?",
                new[] { "Array", "List<T>", "Dictionary<TKey, TValue>", "Queue<T>" }, 2));
            questions.Add(new Question(5, "Как называется пространство имён для базовых классов .NET?",
                new[] { "System", "Microsoft", "Core", "Net" }, 1));
        }
        public void Start()
        {
            stopwatch.Start();
        }

        public void Stop()
        {
            stopwatch.Stop();
        }
        public int QuestionCount => questions.Count;
        public Question GetQuestion(int index)
        {
            return questions[index];
        }
        public bool CheckAnswer(int questionIndex, int userAnswer)
        {
            bool isCorrect = userAnswer == questions[questionIndex].CorrectAnswer;
            if (isCorrect)
                correctAnswersCount++;
            return isCorrect;
        }
        public (int CorrectAnswers, double ElapsedSeconds) GetResults()
        {
            return (correctAnswersCount, stopwatch.Elapsed.TotalSeconds);
        }
    }
}
