using System;

namespace _4_quiz_app
{
    public class ConsoleManager
    {
        Quiz quiz = new Quiz();
        public void Start()
        {
            quiz.Start();

            for (int i = 0; i < quiz.QuestionCount; i++)
            {
                Question question = quiz.GetQuestion(i);
                DisplayQuestion(question);
                int userAnswer = GetUserAnswer();
                bool isCorrect = quiz.CheckAnswer(i, userAnswer);
                DisplayAnswerFeedback(isCorrect, question);
                WaitForContinue();
                Console.Clear();
            }

            quiz.Stop();
            DisplayResults();
        }

        private void DisplayQuestion(Question question)
        {
            Console.WriteLine($"Вопрос {question.QuestionNumber}: {question.Text}");
            for (int i = 0; i < question.Options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {question.Options[i]}");
            }
            Console.Write("Ваш ответ (1-4): ");
        }

        private int GetUserAnswer()
        {
            while (true)
            {
                string input = Console.ReadLine().Trim();
                if (int.TryParse(input, out int answer) && answer >= 1 && answer <= 4)
                {
                    return answer;
                }
                Console.Write("Пожалуйста, введите число от 1 до 4: ");
            }
        }

        private void DisplayAnswerFeedback(bool isCorrect, Question question)
        {
            if (isCorrect)
            {
                Console.WriteLine("Правильно!");
            }
            else
            {
                Console.WriteLine($"Неправильно. Правильный ответ: {question.CorrectAnswer} ({question.Options[question.CorrectAnswer - 1]})");
            }
        }

        private void WaitForContinue()
        {
            Console.WriteLine("Нажмите Enter для продолжения...");
            Console.ReadLine();
        }

        private void DisplayResults()
        {
            var (correctAnswers, elapsedSeconds) = quiz.GetResults();
            Console.WriteLine("\n=== Результаты теста ===");
            Console.WriteLine($"Правильных ответов: {correctAnswers} из {quiz.QuestionCount}");
            double percentage = (double)correctAnswers / quiz.QuestionCount * 100;
            Console.WriteLine($"Процент правильных ответов: {percentage:F2}%");
            Console.WriteLine($"Время выполнения: {elapsedSeconds:F2} секунд");

            if (percentage >= 60)
            {
                Console.WriteLine("Тест пройден успешно!");
            }
            else
            {
                Console.WriteLine("Тест не пройден. Попробуйте ещё раз!");
            }
        }
    }
}
