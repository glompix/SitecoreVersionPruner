﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;

namespace Sitecore.SharedSource.VersionPruner.Rules.Conditions
{
    public class LastModifiedCondition<T> : WhenCondition<T> where T : RuleContext
    {
        public int Value { get; set; }

        protected override bool Execute(T ruleContext)
        {
            Assert.ArgumentNotNull((object)ruleContext, "ruleContext");
            var version = ruleContext.Item;

            return (DateTime.Now - version.Statistics.Updated).Days > this.Value;
        }
    }
}

