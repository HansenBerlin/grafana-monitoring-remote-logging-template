using Prometheus;

namespace RemoteLoggingBlazorExample.MetricExamples;

public static class Monitor
{
    public static readonly Counter ProcessedJobCount = Metrics
        .CreateCounter("jobs_processed_total", "Number of processed jobs.");
    
    public static readonly Gauge JobsInQueue = Metrics
        .CreateGauge("jobs_queued", "Number of jobs waiting for processing in the queue.");
    
    public static readonly Histogram OrderValueHistogram = Metrics
        .CreateHistogram("order_value_usd", "Histogram of received order values (in USD).",
            new HistogramConfiguration
            {
                Buckets = Histogram.LinearBuckets(start: 100, width: 100, count: 10)
            });
    
    public static readonly Summary RequestSizeSummary = Metrics
        .CreateSummary("request_size_bytes", "Summary of request sizes (in bytes) over last 10 minutes.",
            new SummaryConfiguration
            {
                Objectives = new[]
                {
                    new QuantileEpsilonPair(0.5, 0.05),
                    new QuantileEpsilonPair(0.9, 0.05),
                    new QuantileEpsilonPair(0.95, 0.01),
                    new QuantileEpsilonPair(0.99, 0.005),
                }
            });


}