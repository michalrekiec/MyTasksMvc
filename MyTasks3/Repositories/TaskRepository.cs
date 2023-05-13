﻿using Microsoft.EntityFrameworkCore;
using MyTasks3.Data;
using MyTasks3.Interfaces;
using MyTasks3.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTasks3.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private IApplicationDbContext _context;

        public TaskRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Task> Get(string userId, 
            bool isExecuted = false, 
            int categoryId = 0, 
            string title = null)
        {
            var tasks = _context.Tasks.Include(x => x.Category)
                .Where(x => x.UserId == userId && x.IsExecuted == isExecuted);

            if (categoryId != 0)
                tasks = tasks.Where(x => x.CategoryId == categoryId);

            if (!string.IsNullOrEmpty(title))
                tasks = tasks.Where(x => x.Title.Contains(title));

            return tasks.OrderBy(x => x.Term).ToList();
        }

        public IEnumerable<Category> GetCategories(string userId)
        {
            return _context.Categories.Where(x => x.UserId == userId)
                .OrderBy(x => x.Name).ToList();
        }

        public Task Get(int id, string userId)
        {
            var task = _context.Tasks.Single(x => x.Id == id && x.UserId == userId);

            return task;
        }

        public void AddMainCategory(string userId)
        {
            var quantityOfCategories = _context.Categories.Where(x => x.UserId == userId).ToList().Count();

            if (quantityOfCategories == 0)
            {
                var mainCategory = new Category
                {
                    Name = "Ogólna",
                    ColorRGB = "000000",
                    IsMainCategory = true,
                    UserId = userId
                };

                _context.Categories.Add(mainCategory);
            }
        }

        public void Add(Task task)
        {
            _context.Tasks.Add(task);
        }

        public void Update(Task task)
        {
            var taskToUpdate = _context.Tasks.Single(x => x.Id == task.Id);

            taskToUpdate.CategoryId = task.CategoryId;
            taskToUpdate.Description = task.Description;
            taskToUpdate.IsExecuted = task.IsExecuted;
            taskToUpdate.Term = task.Term;
            taskToUpdate.Title = task.Title;
        }

        public void Delete(int id, string userId)
        {
            var taskToDelete = _context.Tasks.Single(x => x.Id == id && x.UserId == userId);

            _context.Tasks.Remove(taskToDelete);
        }

        public void Finish(int id, string userId)
        {
            var taskToUpdate = _context.Tasks
                .Single(x => x.Id == id && x.UserId == userId);

            taskToUpdate.IsExecuted = true;
        }
    }
}
