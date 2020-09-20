using System;
using System.Collections.Generic;
using System.Text;
using API.Controllers;
using API.DTOs;
using API.Mappers;
using AutoMapper;
using Business.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace UnitTests
{
    public class TestPermissionController
    {
        PermissionController _controller;
        IPermissionBusiness _service;
        private readonly IMapper _mapper;

        public TestPermissionController()
        {
            _service = new PermissionBusinessFake();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            _mapper = mockMapper.CreateMapper();
            _controller = new PermissionController(_service, _mapper);
        }

        [Fact]
        public void TestGetAll()
        {
            var okResult = _controller.GetPermissions();
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void TestGet()
        {
            var okResult = _controller.GetPermission(1);
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
    }
}
