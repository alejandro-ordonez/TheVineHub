using Xunit;

// Disable parallel execution to make integration test logs easier to read and prevent DB conflicts
[assembly: CollectionBehavior(DisableTestParallelization = true)]
