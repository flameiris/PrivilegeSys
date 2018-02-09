using System;
using System.Collections.Generic;
using System.Text;

namespace FlameIris.Utility.Json
{
    public class AjaxResult
    {
        private AjaxResult()
        {

        }

        private bool iserror = false;
        public string RedirectUrl { get; set; }
        /// <summary>
        /// 是否产生错误
        /// </summary>
        public bool IsError { get { return iserror; } }
        public int ErrorCode { get; set; }
        /// <summary>
        /// 错误信息，或者成功信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 成功可能时返回的数据
        /// </summary>
        public object Data { get; set; }



        #region Error
        public static AjaxResult Error()
        {
            return new AjaxResult()
            {
                iserror = true
            };
        }
        public static AjaxResult Error(string message)
        {
            return new AjaxResult()
            {
                iserror = true,
                Message = message
            };
        }

        #endregion

        #region Success
        public static AjaxResult Success()
        {
            return new AjaxResult()
            {
                iserror = false,
                Message = "操作成功"
            };
        }
        public static AjaxResult Success(string message)
        {
            return new AjaxResult()
            {
                iserror = false,
                Message = message
            };
        }
        public static AjaxResult Error(object data)
        {
            return new AjaxResult()
            {
                iserror = true,
                Data = data
            };
        }
        public static AjaxResult Success(object data)
        {
            return new AjaxResult()
            {
                iserror = false,
                Data = data
            };
        }
        public static AjaxResult Success(string message, object data)
        {
            return new AjaxResult()
            {
                iserror = false,
                Data = data,
                Message = message
            };
        }
        public static AjaxResult Redirect(string Url)
        {
            return new AjaxResult()
            {
                iserror = false,
                RedirectUrl = Url,

            };
        }
        #endregion
        public static AjaxResult Result(string message, bool b = true)
        {
            return new AjaxResult()
            {
                Message = message
            };
        }

    }

}
