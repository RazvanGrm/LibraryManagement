﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Data.Interfaces;


namespace LibraryManagement.Controllers
{
    public class ReturnController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;

        public ReturnController(IBookRepository bookRepository, ICustomerRepository customerRepository)
        {
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
        }

        public IActionResult List()
        {
            var lendedBooks = _bookRepository.FindWithAuthorAndBorrower(x => x.BorrowerId != 0);

            if (lendedBooks == null || lendedBooks.ToList().Count() == 0)
            {
                return View("Empty");
            }

            return View(lendedBooks);
        }

        public IActionResult ReturnABook(int bookId)
        {
            var book = _bookRepository.GetById(bookId);

            book.Borrower = null;

            book.BorrowerId = 0;

            _bookRepository.Update(book);

            return RedirectToAction("List");
        }
    }
}
