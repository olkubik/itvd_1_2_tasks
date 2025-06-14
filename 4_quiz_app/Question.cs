using System;

namespace _4_quiz_app
{
    public class Question
    {
        public string Text { get; }
        public string[] Options { get; }
        public int CorrectAnswer { get; }
        public int QuestionNumber { get; }

        public Question(int questionNumber, string text, string[] options, int correctAnswer)
        {
            if (options.Length != 4)
                throw new ArgumentException("Ошибка! Должно быть 4 варианта ответа.");
            if (correctAnswer < 1 || correctAnswer > 4)
                throw new ArgumentException("Ошибка! Правильный ответ от 1 до 4");

            QuestionNumber = questionNumber;
            Text = text;
            Options = options;
            CorrectAnswer = correctAnswer;
        }
    }
}
