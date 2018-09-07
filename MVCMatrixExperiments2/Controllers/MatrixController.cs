using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMatrixExperiments2.Models;

namespace MVCMatrixExperiments2.Controllers
{
    public class MatrixController : Controller
    {
        [HttpGet]
        public ActionResult GetInverse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetInverse(TwoByTwoMatrix inputMatrix)
        {
            if (ModelState.IsValid)
            {
                TwoByTwoMatrix inverseMatrix = inputMatrix.GetInverse();

                return inverseMatrix == null ? View("NoInverse") : View("Result", inverseMatrix); 
            }

            return View(inputMatrix);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(TwoByTwoMatrix[] inputMatrices)
        {
            if (ModelState.IsValid)
            {
                TwoByTwoMatrix firstMatrix = inputMatrices[0];
                TwoByTwoMatrix secondMatrix = inputMatrices[1];

                TwoByTwoMatrix resultMatrix = firstMatrix.Add(secondMatrix);

                return View("Result", resultMatrix); 
            }

            return View(inputMatrices);
        }

        [HttpGet]
        public ActionResult Subtract()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Subtract(TwoByTwoMatrix[] inputMatrices)
        {
            if (ModelState.IsValid)
            {
                TwoByTwoMatrix firstMatrix = inputMatrices[0];
                TwoByTwoMatrix secondMatrix = inputMatrices[1];

                TwoByTwoMatrix resultMatrix = firstMatrix.Subtract(secondMatrix);

                return View("Result", resultMatrix); 
            }

            return View(inputMatrices);
        }

        [HttpGet]
        public ActionResult Multiply()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Multiply(TwoByTwoMatrix[] inputMatrices)
        {
            if (ModelState.IsValid)
            {
                TwoByTwoMatrix firstMatrix = inputMatrices[0];
                TwoByTwoMatrix secondMatrix = inputMatrices[1];

                TwoByTwoMatrix resultMatrix = firstMatrix.Multiply(secondMatrix);

                return View("Result", resultMatrix); 
            }

            return View(inputMatrices);
        }
    }
}