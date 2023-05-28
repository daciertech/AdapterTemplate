using Dacier.Scheduler;
using Dacier.Scheduler.Assimilator;
using System.ComponentModel.DataAnnotations;

namespace SampleJobs
{
    /// <summary>
    /// The SampleJobs.SayHello class defines the properties of the SayHello job adapter.
    /// 
    /// Job adapters must have the Dacier.Scheduler.Job class in thier object hierarchy. That is
    /// often the base class.
    /// 
    /// Job adapters need a couple attributes:
    /// 
    /// - YamlKind - This defines the name that will be used in a yaml "Kind:" tag to identify this job adapter.
    /// - OperationProcessor - This identifies the class that is used to "process" this job adapter. A job is processed
    /// when a new active instance is added to the schedule.
    /// </summary>
    [YamlKind("sayhello")]
    [OperationProcessor("SampleJobs.Runner.SayHelloOperationProcessor, SampleJobs.Runner")]
    public class SayHello : Job
    {
        /// <summary>
        /// The greeting to be displayed.
        /// </summary>
        [PropertyId(1)]
        [Required]
        [MinLength(4)]
        public string Greeting { get; set; } = string.Empty;

        /// <summary>
        /// The list of people we should greet.
        /// </summary>
        [PropertyId(2)]
        public List<Person> WhomToGreet { get; } = new();
    }

    /// <summary>
    /// The Person class is used by the SayHello job adapter.
    /// </summary>
    public class Person
    {
        [PropertyId(1)]
        public string Name { get; set; } = string.Empty;
        [PropertyId(2)]
        public string Title { get; set; } = string.Empty;
    }
}