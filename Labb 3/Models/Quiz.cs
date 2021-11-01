﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Labb_3.Models
{
    public class Quiz
    {
        private ICollection<Question> _questions;
        public ICollection<Question> Questions
        {
            get => _questions;
            set => _questions = value;
        }

        private readonly List<int> _shownQuestions = new List<int>();

        private string _title;
        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public Question GetRandomQuestion()
        {
            bool doWeHaveAQuestion = false;
            var random = new Random();
            var question = random.Next(_questions.Count);
            while (!doWeHaveAQuestion)
            {
                if (_shownQuestions.Contains(question))
                {
                    //todo Skapa snyggare lösning.
                    if (_shownQuestions.Count == _questions.Count)
                    {
                        return null;
                    }
                    else
                    {
                        question = random.Next(_questions.Count);
                    }
                    
                }
                else
                {
                    _shownQuestions.Add(question);
                    doWeHaveAQuestion = true;
                }
            }
            return _questions.ToList()[question];
        }

        public void AddQuestion(string statement, int correctAnswer, params string[] answers)
        
        {
            Question question = new(statement, correctAnswer, answers);
            //_questions.Add(question);
            _questions.Add(question);
        }

        public void RemoveQuestion(int index)
        {
            //_questions.RemoveAt(index);
        }

        public Quiz(string title)
        {
            _title = title;
            _questions = new List<Question>();
        }

    }
}