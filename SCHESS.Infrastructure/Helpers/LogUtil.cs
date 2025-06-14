using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCHESS.Infrastructure.Helpers
{
    public class LogRequest
    {
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }
        public string? ApiUrl { get; set; }
        public string? Payload { get; set; }
        public string? Message { get; set; }
        public string? DeviceInfo { get; set; }
        public string? IpAddress { get; set; }
        public string? HostName { get; set; }
        public string? Method { get; set; }
        public string? Path { get; set; }
        public int StatusCode { get; set; }
    }

    public static class LogUtil
    {
        public static void Info(log4net.ILog logger, LogRequest request)
        {
            logger.Info($"Host: {request.HostName} - Path: {request.Path} - Method: {request.Method} Ip address: {request.IpAddress} - Device info: {request.DeviceInfo} - Controller: {request.ControllerName} - Action: {request.ActionName} - ApiUrl: {request.ApiUrl} - Message: {request.Message}");
        }

        public static void Error(log4net.ILog logger, LogRequest request)
        {
            logger.Error($"Host: {request.HostName} - Path: {request.Path} - Method: {request.Method} Ip address: {request.IpAddress} - Device info: {request.DeviceInfo} - Controller: {request.ControllerName} - Action: {request.ActionName} - ApiUrl: {request.ApiUrl} - Message: {request.Message}");
        }
        public static void Warn(log4net.ILog logger, LogRequest request)
        {
            logger.Warn($"Host: {request.HostName} - Path: {request.Path} - Method: {request.Method} Ip address: {request.IpAddress} - Device info: {request.DeviceInfo} - Controller: {request.ControllerName} - Action: {request.ActionName} - ApiUrl: {request.ApiUrl} - Message: {request.Message}");
        }
    }
}
