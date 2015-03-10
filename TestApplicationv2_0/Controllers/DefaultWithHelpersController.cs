﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoSessionHelpers;

namespace TestApplicationv2_0.Controllers
{
    public class DefaultWithHelpersController : Controller
    {
        //
        // GET: /DefaultWithHelpers/

        private const string KEY_NAME = "value";
        public const string VIEW_DATA_VAL = "sessionVal";

        public ActionResult Index()
        {
            this.SetMongoSession<string>(KEY_NAME, "Hi");
            return View();
        }

        public ActionResult PrintSessionValString()
        {
            string val = this.GetMongoSession<string>(KEY_NAME);

            ViewBag.sessionVal = val;
            return View("~/Views/Default/PrintSessionVal.aspx");
        }

        public ActionResult PrintSessionValDouble()
        {
            double dobVal = this.GetMongoSession<double>(KEY_NAME);

            ViewBag.sessionVal = dobVal.ToString("G");
            return View("~/Views/Default/PrintSessionVal.aspx");
        }

        public ActionResult SetSessionValInt(int newSesVal = 0)
        {
            this.SetMongoSession<int>(KEY_NAME, newSesVal);

            return View("~/Views/Default/SetSessionVal.aspx");
        }

        public ActionResult SetSessionValBool(bool newSesVal = false)
        {
            this.SetMongoSession<bool>(KEY_NAME, newSesVal);

            return View("~/Views/Default/SetSessionVal.aspx");
        }

        public ActionResult SetSessionValDouble()
        {
            double newSesVal = 3.1416F;
            this.SetMongoSession<double>(KEY_NAME, newSesVal);

            return View("~/Views/Default/SetSessionVal.aspx");
        }

        public ActionResult SetSessionVal(string newSesVal = "")
        {
            this.SetMongoSession<string>(KEY_NAME, newSesVal);

            return View();
        }
    }
}
