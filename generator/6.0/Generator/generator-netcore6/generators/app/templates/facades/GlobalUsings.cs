﻿// <auto-generated/>
[% controllers.forEach(function(controller){ %]global using [%= company %].[%= name %].Common.DTOs.Requests.[%- controller.name %];
[% }); %][% controllers.forEach(function(controller){ %]
global using [%= company %].[%= name %].Common.DTOs.Responses.[%- controller.name %];
[% }); %][% controllers.forEach(function(controller){ %]
global using [%= company %].[%= name %].Facade.[%- controller.name %];
global using [%= company %].[%= name %].Facade.[%- controller.name %].Impl;
[% }); %][% controllers.forEach(function(controller){ %]
global using [%= company %].[%= name %].Services.[%- controller.name %];[% }); %]
global using Microsoft.Extensions.DependencyInjection;