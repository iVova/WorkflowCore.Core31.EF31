using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Test.WorkflowCore.Core31.EF31
{
    public class SomeWorkflow : IWorkflow
    {
        public void Build(IWorkflowBuilder<object> builder)
        {
            builder
                .StartWith(context =>
                {
                    Console.WriteLine("Workflow started");
                    return ExecutionResult.Next();
                })
                .Then(context =>
                {
                    Console.WriteLine("workflow complete");
                    return ExecutionResult.Next();
                });
        }

        public string Id { get; } = "SomeWorkflow";
        public int Version { get; } = 1;
    }
}
