﻿/*==============================================================================================================================
 File Name    : AssertHelper.cs
 ClassName    : AssertHelper
 Summary      : Contains Assertion functions.
 ===============================================================================================================================
 History      :   Company            Date            Action              Author
                  360logica                         Initial Version      Ammar

 ===============================================================================================================================
 Remarks      :   Tests - 
 ===============================================================================================================================*/
using log4net;
using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RallyTeam.TestScripts;

namespace RallyTeam.Util
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class CustomRetry : PropertyAttribute, IWrapSetUpTearDown
    {
        public int _count;
        /// <summary>
        /// Construct a RepeatAttribute
        /// </summary>
        /// <param name="count">The number of times to run the test</param>
        public CustomRetry(int count) : base(count)
        {
            _count = count;
        }

        #region IWrapSetUpTearDown Members

        /// <summary>
        /// Wrap a command and return the result.
        /// </summary>
        /// <param name="command">The command to be wrapped</param>
        /// <returns>The wrapped command</returns>
        public TestCommand Wrap(TestCommand command)
        {
            return new CustomRetryCommand(command, _count);
        }

        #endregion

        #region Nested CustomRetry Class

        /// <summary>
        /// The test command for the RetryAttribute
        /// </summary>
        public class CustomRetryCommand : DelegatingTestCommand
        {
            public int _retryCount;           
            /// <summary>
            /// Initializes a new instance of the <see cref="CustomRetryCommand"/> class.
            /// </summary>
            /// <param name="innerCommand">The inner command.</param>
            /// <param name="retryCount">The number of repetitions</param>
            public CustomRetryCommand(TestCommand innerCommand, int retryCount)
                : base(innerCommand)
            {
                _retryCount = retryCount;
            }

            /// <summary>
            /// Runs the test, saving a TestResult in the supplied TestExecutionContext.
            /// </summary>
            /// <param name="context">The context in which the test should run.</param>
            /// <returns>A TestResult</returns>
            public override TestResult Execute(TestExecutionContext context)
            {
                int count = _retryCount;

                while (count-- > 0)
                {
                    context.CurrentResult = innerCommand.Execute(context);
                    Global.tempCount = count;
                    var results = context.CurrentResult.ResultState;

                    if (results != ResultState.Error
                        && results != ResultState.Failure
                        && results != ResultState.SetUpError
                        && results != ResultState.SetUpFailure
                        && results != ResultState.TearDownError
                        && results != ResultState.ChildFailure)
                    {
                        break;
                    }
                    if (count > 0)
                    {
                        context.CurrentResult = TestExecutionContext.CurrentContext.CurrentTest.MakeTestResult();
                    }
                }

                return context.CurrentResult;
            }
        }

        #endregion
    }
}
