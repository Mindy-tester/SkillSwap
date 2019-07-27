using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Test
{
    class APITest
    {
        [Test]
        public void PostRequestTests()
        {
            //Establish a client
            var client = new RestClient("http://dummy.restapiexample.com/api/v1/create");

            //request
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");

            //add body of teh request
            request.AddParameter("application/json", "{ \"name\":\"alaya\", \"salary\" : \"2000\", \"age\" : \"26\"}", ParameterType.RequestBody);

            //executing the rest request
            var response = client.Execute(request);

            //
            Console.WriteLine("response.statuscode" + response.StatusCode);
            Console.WriteLine("response.content" + response.Content);

            //add assertion
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [Test]

        public void GetRequestTests()
        {

            // Establish a client
            var client = new RestClient("http://dummy.restapiexample.com/api/v1/employees");

            //request
            var request = new RestRequest("http://dummy.restapiexample.com/api/v1/employee/1794", Method.GET);
            request.AddHeader("Content-Type", "application/json");

            //add body of teh request
            //request.AddParameter("application/json", "{ \"name\":\"dhanvi\", \"salary\" : \"2000\", \"age\" : \"26\"}", ParameterType.RequestBody);

            //executing the rest request
            var response = client.Execute(request);

            //
            Console.WriteLine("response.statuscode" + response.StatusCode);
            //Console.WriteLine("response.content" + response.Content);

            //add assertion
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }


        [Test]        public void PutRequestTests()
        {

            // Establish a client
            var client = new RestClient("http://dummy.restapiexample.com/api/v1/employees");

            //request
            var request = new RestRequest("http://dummy.restapiexample.com/api/v1/update/1794", Method.PUT);
            request.AddHeader("Content-Type", "application/json");

            //add body of the request
            request.AddParameter("application/json", "{ \"name\":\"ram\", \"salary\" : \"2000\", \"age\" : \"26\"}", ParameterType.RequestBody);

            //executing the rest request
            var response = client.Execute(request);

            //
            Console.WriteLine("response.statuscode" + response.StatusCode);
            Console.WriteLine("response.content" + response.Content);

            //add assertion
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

        [Test]

        public void DeleteRequestTests()
        {
            // Establish a client
            var client = new RestClient("http://dummy.restapiexample.com/api/v1/employees");

            //request
            var request = new RestRequest("http://dummy.restapiexample.com/api/v1/delete/1794", Method.DELETE);
            request.AddHeader("Content-Type", "application/json");

           
            //executing the rest request
            var response = client.Execute(request);

            //
            Console.WriteLine("response.statuscode" + response.StatusCode);
            Console.WriteLine("response.content" + response.Content);

            //add assertion
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }


}

