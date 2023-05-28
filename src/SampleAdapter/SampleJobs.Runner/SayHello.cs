using Dacier.Scheduler;

namespace SampleJobs.Runner
{
    /// <summary>
    /// The SampleJobs.Runner.SayHello class is responsible for executing a SayHello job.
    /// 
    /// The GenericActive class must be at the base of the object hierarchy but there are
    /// several helper classes that you can use as a base class. One example is the
    /// Dacier.Scheduler.ActiveProcess class which is used by jobs that need to run in
    /// thier own process.
    /// </summary>
    public class SayHello : GenericActive
    {
        public SampleJobs.SayHello OurInstance { get; set; }

        /// <summary>
        /// The StartJob method is called by the Dacier Scheduler when it is time to
        /// start the job.
        /// </summary>
        /// <param name="feedback"></param>
        /// <returns></returns>
        public override async Task StartJob(IActiveFeedback feedback)
        {
            await feedback.WriteLogMessage($"Starting executing of the {OurInstance.Name} instance of SayHello");

            foreach (var person in OurInstance.WhomToGreet)
            {
                await feedback.WriteLogMessage(string.Format(OurInstance.Greeting, person.Title, person.Name));
            }
        }
    }
}