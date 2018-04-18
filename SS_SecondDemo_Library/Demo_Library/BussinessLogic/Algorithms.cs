﻿using Demo_Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo_Library.BussinessLogic
{
    public static class Algorithms
    {
        //Sorting algorithms
        //Bubble sort
        public static IList<IBook> SortYearBubble(IList<IBook> books, string order)
        {

            for (int p = books.Count - 1; p > 0; p--)
            {
                for (int i = 0; i <= p - 1; i++)
                {
                    if (order == "ascending" || order == "asc")
                    {
                        if (books[i].YearPublished > (books[i + 1].YearPublished))
                        {
                            IBook temp = books[i + 1];
                            books[i + 1] = books[i];
                            books[i] = temp;
                        }
                    }
                    else
                    {
                        if (books[i].YearPublished < (books[i + 1].YearPublished))
                        {
                            IBook temp = books[i + 1];
                            books[i + 1] = books[i];
                            books[i] = temp;
                        }
                    }
                }
            }

            return books;
        }

        public static IList<IBook> SortAuthorNameBubble(IList<IBook> books, string order)
        {

            for (int p = books.Count - 1; p > 0; p--)
            {
                for (int i = 0; i <= p - 1; i++)
                {
                    if (order == "ascending" || order == "asc")
                    {
                        if (String.Compare(books[i].Author.Name, (books[i + 1].Author.Name)) > 0)
                        {
                            IBook temp = books[i + 1];
                            books[i + 1] = books[i];
                            books[i] = temp;
                        }
                    }
                    else
                    {
                        if (String.Compare(books[i].Author.Name, (books[i + 1].Author.Name)) < 0)
                        {
                            IBook temp = books[i + 1];
                            books[i + 1] = books[i];
                            books[i] = temp;
                        }
                    }
                }
            }
              
            return books;
        }

        //Merge sort
        public static IList<IBook> SortYearMerge(IList<IBook> books, string order)
        {
            if (books.Count <= 1)
            {
                return books;
            }

            IList<IBook> leftPart = new List<IBook>();
            IList<IBook> rightPart = new List<IBook>();

            int middle = books.Count / 2;

            for (int i = 0; i < middle; i++)
            {
                leftPart.Add(books[i]);
            }
            for (int i = middle; i < books.Count; i++)
            {
                rightPart.Add(books[i]);
            }

            leftPart = SortYearMerge(leftPart, order);
            rightPart = SortYearMerge(rightPart, order);
            return SortYearMergeHelper(leftPart, rightPart, order);

        }
        private static IList<IBook> SortYearMergeHelper(IList<IBook> leftPart, IList<IBook> rightPart, string order)
        {
            IList<IBook> result = new List<IBook>();

            while (leftPart.Count > 0 || rightPart.Count > 0)
            {
                if (leftPart.Count > 0 && rightPart.Count > 0)
                {
                    if (order == "ascending" || order == "asc")
                    {
                        if (leftPart.First().YearPublished <= rightPart.First().YearPublished)
                        {
                            result.Add(leftPart.First());
                            leftPart.Remove(leftPart.First());
                        }
                        else
                        {
                            result.Add(rightPart.First());
                            rightPart.Remove(rightPart.First());
                        }
                    }
                    else
                    {
                        if (leftPart.First().YearPublished > rightPart.First().YearPublished)
                        {
                            result.Add(leftPart.First());
                            leftPart.Remove(leftPart.First());
                        }
                        else
                        {
                            result.Add(rightPart.First());
                            rightPart.Remove(rightPart.First());
                        }
                    }
                }
                else if (leftPart.Count > 0)
                {
                    result.Add(leftPart.First());
                    leftPart.Remove(leftPart.First());
                }
                else if (rightPart.Count > 0)
                {
                    result.Add(rightPart.First());
                    rightPart.Remove(rightPart.First());
                }
            }
            return result;
        }

        public static IList<IBook> SortAuthorMerge(IList<IBook> books, string order)
        {
            if (books.Count <= 1)
            {
                return books;
            }

            IList<IBook> leftPart = new List<IBook>();
            IList<IBook> rightPart = new List<IBook>();

            int middle = books.Count / 2;

            for (int i = 0; i < middle; i++)
            {
                leftPart.Add(books[i]);
            }
            for (int i = middle; i < books.Count; i++)
            {
                rightPart.Add(books[i]);
            }

            leftPart = SortAuthorMerge(leftPart, order);
            rightPart = SortAuthorMerge(rightPart, order);
            return SortAuthorMergeHelper(leftPart, rightPart, order);

        }
        private static IList<IBook> SortAuthorMergeHelper(IList<IBook> leftPart, IList<IBook> rightPart, string order)
        {
            IList<IBook> result = new List<IBook>();

            while (leftPart.Count > 0 || rightPart.Count > 0)
            {
                if (leftPart.Count > 0 && rightPart.Count > 0)
                {
                    if (order == "ascending" || order == "asc")
                    {
                        if (String.Compare(leftPart.First().Author.Name, rightPart.First().Author.Name) <= 0)
                        {
                            result.Add(leftPart.First());
                            leftPart.Remove(leftPart.First());
                        }
                        else
                        {
                            result.Add(rightPart.First());
                            rightPart.Remove(rightPart.First());
                        }
                    }
                    else
                    {
                        if (String.Compare(leftPart.First().Author.Name, rightPart.First().Author.Name) > 0)
                        {
                            result.Add(leftPart.First());
                            leftPart.Remove(leftPart.First());
                        }
                        else
                        {
                            result.Add(rightPart.First());
                            rightPart.Remove(rightPart.First());
                        }
                    }
                }
                else if (leftPart.Count > 0)
                {
                    result.Add(leftPart.First());
                    leftPart.Remove(leftPart.First());
                }
                else if (rightPart.Count > 0)
                {
                    result.Add(rightPart.First());
                    rightPart.Remove(rightPart.First());
                }
            }

            return result;
        }

        //Merge sort (ascending) on ISBN helping the binary search
        public static IList<IBook> SortISBNMerge(IList<IBook> books)
        {
            if (books.Count <= 1)
            {
                return books;
            }

            IList<IBook> leftPart = new List<IBook>();
            IList<IBook> rightPart = new List<IBook>();

            int middle = books.Count / 2;

            for (int i = 0; i < middle; i++)
            {
                leftPart.Add(books[i]);
            }
            for (int i = middle; i < books.Count; i++)
            {
                rightPart.Add(books[i]);
            }

            leftPart = SortISBNMerge(leftPart);
            rightPart = SortISBNMerge(rightPart);
            return SortISBNMergeHelper(leftPart, rightPart);

        }
        private static IList<IBook> SortISBNMergeHelper(IList<IBook> leftPart, IList<IBook> rightPart)
        {
            IList<IBook> result = new List<IBook>();

            while (leftPart.Count > 0 || rightPart.Count > 0)
            {
                if (leftPart.Count > 0 && rightPart.Count > 0)
                {
                    if (leftPart.First().ISBN <= rightPart.First().ISBN)
                    {
                        result.Add(leftPart.First());
                        leftPart.Remove(leftPart.First());
                    }
                    else
                    {
                        result.Add(rightPart.First());
                        rightPart.Remove(rightPart.First());
                    }

                }
                else if (leftPart.Count > 0)
                {
                    result.Add(leftPart.First());
                    leftPart.Remove(leftPart.First());
                }
                else if (rightPart.Count > 0)
                {
                    result.Add(rightPart.First());
                    rightPart.Remove(rightPart.First());
                }
            }

            return result;
        }

        //Binary search on ISBN
        public static IBook BinarySearchPerISBN(IList<IBook> books, long isbnToSearch)
        {
            int left = 0;
            int right = books.Count - 1;

            while (left <= right)
            {
                int middle = (left + right) / 2;

                if (books[middle].ISBN > isbnToSearch)
                {
                    right = middle - 1;
                }
                else if (books[middle].ISBN < isbnToSearch)
                {
                    left = middle + 1;
                }
                else
                {
                    return books[middle];
                }
            }

            return null;
        }
    }
}