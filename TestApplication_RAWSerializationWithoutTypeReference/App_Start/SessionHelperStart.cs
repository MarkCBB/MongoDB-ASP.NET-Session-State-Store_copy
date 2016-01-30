﻿using MongoSessionStateStore.SessionHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApplication_RAWSerializationWithoutTypeReference
{
    public static class SessionHelperStart
    {
        public static void InitSessionHelper()
        {
            System.Web.Mvc.MongoSessionUserHelpersMvc.SetHelper(new SessionHelperPersonalizedPartial());
        }
    }

    public class SessionHelperPersonalizedPartial : SessionHelper
    {
        public override T getObjValue<T>(object sessionObj)
        {
            if (sessionObj is string)
            {
                sessionObj = "This is a sample class of a partial personalized helper";
                return (T)sessionObj;
            }
            else
                return default(T);
        }
    }
    
    public class SessionHelperPersonalized : ISessionHelper
    {
        public T getObjValue<T>(object sessionObj)
        {
            if (sessionObj is string)
            {
                sessionObj = "This is a sample class of a full personalized helper";
                return (T)sessionObj;
            }
            else
                return default(T);
        }

        public T Mongo<T>(HttpSessionStateBase session, string key)
        {
            var sessionObj = session[key];
            return getObjValue<T>(sessionObj);
        }

        public void Mongo<T>(HttpSessionStateBase session, string key, T newValue)
        {
            session[key] = newValue;
        }

        public T Mongo<T>(System.Web.SessionState.HttpSessionState session, string key)
        {
            var sessionObj = session[key];
            return getObjValue<T>(sessionObj);
        }

        public void Mongo<T>(System.Web.SessionState.HttpSessionState session, string key, T newValue)
        {
            session[key] = newValue;
        }
    }
}