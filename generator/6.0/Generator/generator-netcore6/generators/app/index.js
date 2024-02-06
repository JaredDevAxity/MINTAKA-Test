const config = require("./config.json");
var randomWords = require('random-words');
var Generator = require('yeoman-generator');

function formatting(data){
    return JSON.stringify(data)
}

module.exports = class extends Generator {

    initializing() {

        config.controllers.sort(function (a, b) {
            if (a.name < b.name) { return -1; }
            if (a.name > b.name) { return 1; }
            return 0;
        });

        this.props = {
            company: config.company,
            name: config.name,
            port: config.port,
            controllers: config.controllers,
        };
    }

    writing() {

        var done = this.async();

        this.log(randomWords());

        this.fs.copyTpl(
            this.templatePath('api-service/**'),
            this.destinationPath(`${this.props.name.toLowerCase()}-service/`), {
            name: this.props.name,
            namelower: this.props.name.toLowerCase(),
            port: this.props.port,
            company: this.props.company,
        },
            {
                openDelimiter: '[',
                closeDelimiter: ']'
            }
        );

        this.fs.copyTpl(
            this.templatePath('api-service/*/**/*'),
            this.destinationPath(`${this.props.name.toLowerCase()}-service/`), {
            name: this.props.name,
            namelower: this.props.name.toLowerCase(),
            port: this.props.port,
            company: this.props.company,
        },
            {
                openDelimiter: '[',
                closeDelimiter: ']'
            }
        );

        this.fs.copyTpl(
            this.templatePath('api-service/.gitignore'),
            this.destinationPath(`${this.props.name.toLowerCase()}-service/.gitignore`)
        );

        this.fs.copyTpl(
            this.templatePath('api-service/.editorconfig'),
            this.destinationPath(`${this.props.name.toLowerCase()}-service/.editorconfig`)
        );

        this.props.controllers.forEach(controller => {

            controller.data = controller.data.map(data => formatting(data));

            let existGet = controller.actions.some(item => item === "get");
            let existPost = controller.actions.some(item => item === "post");
            let existPut = controller.actions.some(item => item === "put");
            let existDelete = controller.actions.some(item => item === "delete");

            /* Controllers */
            this.fs.copyTpl(
                this.templatePath('controllers/MasterController.cs'),
                this.destinationPath(`${this.props.name.toLowerCase()}-service/${this.props.company}.${this.props.name}.API/Controllers/${controller.name}Controller.cs`),
                {
                    name: this.props.name,
                    namelower: this.props.name.toLowerCase(),
                    company: this.props.company,
                    controllerName: controller.name,
                    controllerNameLower: controller.name.toLowerCase(),
                    singularControllerName: controller.singularName,
                    singularControllerNameLower: controller.singularName.toLowerCase(),
                    controllerGet: existGet,
                    controllerPost: existPost,
                    controllerPut: existPut,
                    controllerDelete: existDelete
                },
                {
                    openDelimiter: '[',
                    closeDelimiter: ']'
                });

            this.fs.copyTpl(
                this.templatePath('controllers/GlobalUsings.cs'),
                this.destinationPath(`${this.props.name.toLowerCase()}-service/${this.props.company}.${this.props.name}.API/GlobalUsings.cs`),
                {
                    name: this.props.name,
                    company: this.props.company,
                    controllers: this.props.controllers
                },
                {
                    openDelimiter: '[',
                    closeDelimiter: ']'
                });

            /* Facades */
            this.fs.copyTpl(
                this.templatePath('facades/IMasterFacade.cs'),
                this.destinationPath(`${this.props.name.toLowerCase()}-service/${this.props.company}.${this.props.name}.Facade/${controller.name}/I${controller.name}Facade.cs`),
                {
                    name: this.props.name,
                    namelower: this.props.name.toLowerCase(),
                    port: this.props.port,
                    company: this.props.company,
                    controllerName: controller.name,
                    controllerNameLower: controller.name.toLowerCase(),
                    singularControllerName: controller.singularName,
                    singularControllerNameLower: controller.singularName.toLowerCase(),
                    controllerGet: existGet,
                    controllerPost: existPost,
                    controllerPut: existPut,
                    controllerDelete: existDelete
                },
                {
                    openDelimiter: '[',
                    closeDelimiter: ']'
                });

            this.fs.copyTpl(
                this.templatePath('facades/MasterFacade.cs'),
                this.destinationPath(`${this.props.name.toLowerCase()}-service/${this.props.company}.${this.props.name}.Facade/${controller.name}/Impl/${controller.name}Facade.cs`),
                {
                    name: this.props.name,
                    namelower: this.props.name.toLowerCase(),
                    port: this.props.port,
                    company: this.props.company,
                    controllerName: controller.name,
                    controllerNameLower: controller.name.toLowerCase(),
                    singularControllerName: controller.singularName,
                    singularControllerNameLower: controller.singularName.toLowerCase(),
                    controllerGet: existGet,
                    controllerPost: existPost,
                    controllerPut: existPut,
                    controllerDelete: existDelete
                },
                {
                    openDelimiter: '[',
                    closeDelimiter: ']'
                });

            this.fs.copyTpl(
                this.templatePath('facades/DependencyExtension.cs'),
                this.destinationPath(`${this.props.name.toLowerCase()}-service/${this.props.company}.${this.props.name}.Facade/DependencyExtension.cs`),
                {
                    name: this.props.name,
                    company: this.props.company,
                    controllers: this.props.controllers
                },
                {
                    openDelimiter: '[',
                    closeDelimiter: ']'
                });

            this.fs.copyTpl(
                this.templatePath('facades/GlobalUsings.cs'),
                this.destinationPath(`${this.props.name.toLowerCase()}-service/${this.props.company}.${this.props.name}.Facade/GlobalUsings.cs`),
                {
                    name: this.props.name,
                    company: this.props.company,
                    controllers: this.props.controllers
                },
                {
                    openDelimiter: '[',
                    closeDelimiter: ']'
                });

            /* Services */
            this.fs.copyTpl(
                this.templatePath('services/AutoMapperProfile.cs'),
                this.destinationPath(`${this.props.name.toLowerCase()}-service/${this.props.company}.${this.props.name}.Services/Mapping/AutoMapperProfile.cs`),
                {
                    name: this.props.name,
                    company: this.props.company,
                    controllers: this.props.controllers
                },
                {
                    openDelimiter: '[',
                    closeDelimiter: ']'
                });

            this.fs.copyTpl(
                this.templatePath('services/IMasterService.cs'),
                this.destinationPath(`${this.props.name.toLowerCase()}-service/${this.props.company}.${this.props.name}.Services/${controller.name}/I${controller.name}Service.cs`),
                {
                    name: this.props.name,
                    namelower: this.props.name.toLowerCase(),
                    port: this.props.port,
                    company: this.props.company,
                    controllerName: controller.name,
                    controllerNameLower: controller.name.toLowerCase(),
                    singularControllerName: controller.singularName,
                    singularControllerNameLower: controller.singularName.toLowerCase(),
                    controllerGet: existGet,
                    controllerPost: existPost,
                    controllerPut: existPut,
                    controllerDelete: existDelete
                },
                {
                    openDelimiter: '[',
                    closeDelimiter: ']'
                });

            this.fs.copyTpl(
                this.templatePath('services/MasterService.cs'),
                this.destinationPath(`${this.props.name.toLowerCase()}-service/${this.props.company}.${this.props.name}.Services/${controller.name}/Impl/${controller.name}Service.cs`),
                {
                    name: this.props.name,
                    namelower: this.props.name.toLowerCase(),
                    company: this.props.company,
                    controllerName: controller.name,
                    controllerNameLower: controller.name.toLowerCase(),
                    singularControllerName: controller.singularName,
                    singularControllerNameLower: controller.singularName.toLowerCase(),
                    controllerGet: existGet,
                    controllerPost: existPost,
                    controllerPut: existPut,
                    controllerDelete: existDelete,
                    properties: controller.properties
                },
                {
                    openDelimiter: '[',
                    closeDelimiter: ']'
                });

            this.fs.copyTpl(
                this.templatePath('services/DependencyExtension.cs'),
                this.destinationPath(`${this.props.name.toLowerCase()}-service/${this.props.company}.${this.props.name}.Services/DependencyExtension.cs`),
                {
                    name: this.props.name,
                    company: this.props.company,
                    controllers: this.props.controllers
                },
                {
                    openDelimiter: '[',
                    closeDelimiter: ']'
                });

            this.fs.copyTpl(
                this.templatePath('services/GlobalUsings.cs'),
                this.destinationPath(`${this.props.name.toLowerCase()}-service/${this.props.company}.${this.props.name}.Services/GlobalUsings.cs`),
                {
                    name: this.props.name,
                    company: this.props.company,
                    controllers: this.props.controllers
                },
                {
                    openDelimiter: '[',
                    closeDelimiter: ']'
                });

            /* Model */
            this.fs.copyTpl(
                this.templatePath('entities/Entity.cs'),
                this.destinationPath(`${this.props.name.toLowerCase()}-service/${this.props.company}.${this.props.name}.Model/Entities/${controller.singularName}Model.cs`),
                {
                    name: this.props.name,
                    company: this.props.company,
                    singularControllerName: controller.singularName,
                    properties: controller.properties
                },
                {
                    openDelimiter: '[',
                    closeDelimiter: ']'
                });

            /* Persistence */
            this.fs.copyTpl(
                this.templatePath('persistence/MasterDao.cs'),
                this.destinationPath(`${this.props.name.toLowerCase()}-service/${this.props.company}.${this.props.name}.Persistence/DAO/${controller.name}/Impl/${controller.name}Dao.cs`),
                {
                    name: this.props.name,
                    namelower: this.props.name.toLowerCase(),
                    port: this.props.port,
                    company: this.props.company,
                    controllerName: controller.name,
                    controllerNameLower: controller.name.toLowerCase(),
                    singularControllerName: controller.singularName,
                    singularControllerNameLower: controller.singularName.toLowerCase(),
                    controllerGet: existGet,
                    controllerPost: existPost,
                    controllerPut: existPut,
                    controllerDelete: existDelete
                },
                {
                    openDelimiter: '[',
                    closeDelimiter: ']'
                });

            this.fs.copyTpl(
                this.templatePath('persistence/IMasterDao.cs'),
                this.destinationPath(`${this.props.name.toLowerCase()}-service/${this.props.company}.${this.props.name}.Persistence/DAO/${controller.name}/I${controller.name}Dao.cs`),
                {
                    name: this.props.name,
                    namelower: this.props.name.toLowerCase(),
                    port: this.props.port,
                    company: this.props.company,
                    controllerName: controller.name,
                    controllerNameLower: controller.name.toLowerCase(),
                    singularControllerName: controller.singularName,
                    singularControllerNameLower: controller.singularName.toLowerCase(),
                    controllerGet: existGet,
                    controllerPost: existPost,
                    controllerPut: existPut,
                    controllerDelete: existDelete
                },
                {
                    openDelimiter: '[',
                    closeDelimiter: ']'
                });

            this.fs.copyTpl(
                this.templatePath('persistence/DependencyExtension.cs'),
                this.destinationPath(`${this.props.name.toLowerCase()}-service/${this.props.company}.${this.props.name}.Persistence/DependencyExtension.cs`),
                {
                    name: this.props.name,
                    company: this.props.company,
                    controllers: this.props.controllers
                },
                {
                    openDelimiter: '[',
                    closeDelimiter: ']'
                });

            this.fs.copyTpl(
                this.templatePath('persistence/GlobalUsings.cs'),
                this.destinationPath(`${this.props.name.toLowerCase()}-service/${this.props.company}.${this.props.name}.Persistence/GlobalUsings.cs`),
                {
                    name: this.props.name,
                    company: this.props.company,
                    controllers: this.props.controllers
                },
                {
                    openDelimiter: '[',
                    closeDelimiter: ']'
                });

            this.fs.copyTpl(
                this.templatePath('persistence/context/MasterDatabaseContext.cs'),
                this.destinationPath(`${this.props.name.toLowerCase()}-service/${this.props.company}.${this.props.name}.Persistence/Context/DatabaseContext.cs`),
                {
                    name: this.props.name,
                    company: this.props.company,
                    controllers: this.props.controllers
                },
                {
                    openDelimiter: '[',
                    closeDelimiter: ']'
                });

            let tableSetting = `builder.ToTable("${controller.tableName}")`;
            const primaryKeys = controller.properties.filter(property => property.db.isPrimaryKey);
            if (primaryKeys.length > 1) {
                tableSetting += `.HasKey(p => new { ${primaryKeys.map(primaryKey => 'p.' + primaryKey.name).join(', ')} })`;
            }

            if (primaryKeys.length === 1) {
                tableSetting += `.HasKey(p => p.${primaryKeys[0].name})`;
            }

            tableSetting += ';';
            const propertySettings = [];
            controller.properties.filter(property => !property.db.isPrimaryKey).forEach(property => {
                const configurations = [`builder.Property(s => s.${property.name}).HasColumnName("${property.db.name}")`];
                if (!property.db.allowNull) {
                    configurations.push(`.IsRequired()`);
                }
                if (property.type === 'string' && property.db.maxLength > 0) {
                    configurations.push(`.HasMaxLength(${property.db.maxLength})`);
                }
                configurations.push(";");
                propertySettings.push(configurations.join(""));
            });

            this.fs.copyTpl(
                this.templatePath('persistence/configuration/MasterConfiguration.cs'),
                this.destinationPath(`${this.props.name.toLowerCase()}-service/${this.props.company}.${this.props.name}.Persistence/Configuration/${controller.singularName}Configuration.cs`),
                {
                    name: this.props.name,
                    company: this.props.company,
                    controller: controller,
                    tableSetting: tableSetting,
                    propertySettings: propertySettings
                },
                {
                    openDelimiter: '[',
                    closeDelimiter: ']'
                });

            /* Common */
            this.fs.copyTpl(
                this.templatePath('common/GlobalUsings.cs'),
                this.destinationPath(`${this.props.name.toLowerCase()}-service/${this.props.company}.${this.props.name}.Common/GlobalUsings.cs`),
                {   
                    name: this.props.name,
                    company: this.props.company,
                    controllers: this.props.controllers
                },
                {
                    openDelimiter: '[',
                    closeDelimiter: ']'
                });

            /* Common.Responses */
            this.fs.copyTpl(
                this.templatePath('common/responses/MasterDto.cs'),
                this.destinationPath(`${this.props.name.toLowerCase()}-service/${this.props.company}.${this.props.name}.Common/DTOs/Responses/${controller.name}/${controller.singularName}Dto.cs`),
                {
                    name: this.props.name,
                    company: this.props.company,
                    controllerName: controller.name,
                    singularControllerName: controller.singularName,
                    properties: controller.properties.filter(property => property.includeInResponse)
                },
                {
                    openDelimiter: '[',
                    closeDelimiter: ']'
                });

            /* Common.Requests */
            this.fs.copyTpl(
                this.templatePath('common/requests/MasterCreateOrUpdateDto.cs'),
                this.destinationPath(`${this.props.name.toLowerCase()}-service/${this.props.company}.${this.props.name}.Common/DTOs/Requests/${controller.name}/Create${controller.singularName}Dto.cs`),
                {
                    name: this.props.name,
                    company: this.props.company,
                    controllerName: controller.name,
                    singularControllerName: controller.singularName,
                    properties: controller.properties.filter(property => property.isRequiredToInsert),
                    prefixDto: 'Create'
                },
                {
                    openDelimiter: '[',
                    closeDelimiter: ']'
                });

            this.fs.copyTpl(
                this.templatePath('common/requests/MasterCreateOrUpdateDto.cs'),
                this.destinationPath(`${this.props.name.toLowerCase()}-service/${this.props.company}.${this.props.name}.Common/DTOs/Requests/${controller.name}/Update${controller.singularName}Dto.cs`),
                {
                    name: this.props.name,
                    company: this.props.company,
                    controllerName: controller.name,
                    singularControllerName: controller.singularName,
                    properties: controller.properties.filter(property => property.allowUpdate),
                    prefixDto: 'Update'
                },
                {
                    openDelimiter: '[',
                    closeDelimiter: ']'
                });

            /* Test 
            this.fs.copyTpl(
                this.templatePath('tests/MasterBaseTest.cs'),
                this.destinationPath(`${this.props.name.toLowerCase()}-service/${this.props.company}.${this.props.name}.Test/BaseTest.cs`),
                {
                    name: this.props.name,
                    company: this.props.company,
                    controllers: this.props.controllers
                },
                {
                    openDelimiter: '[',
                    closeDelimiter: ']'
                });

            this.fs.copyTpl(
                this.templatePath('tests/MasterServiceTest.cs'),
                this.destinationPath(`${this.props.name.toLowerCase()}-service/${this.props.company}.${this.props.name}.Test/Services/${controller.singularName}ServiceTest.cs`),
                {
                    name: this.props.name,
                    company: this.props.company,
                    serviceName: controller.singularName
                },
                {
                    openDelimiter: '[',
                    closeDelimiter: ']'
                });

            this.fs.copyTpl(
                this.templatePath('tests/MasterFacadeTest.cs'),
                this.destinationPath(`${this.props.name.toLowerCase()}-service/${this.props.company}.${this.props.name}.Test/Facade/${controller.singularName}FacadeTest.cs`),
                {
                    name: this.props.name,
                    company: this.props.company,
                    serviceName: controller.singularName
                },
                {
                    openDelimiter: '[',
                    closeDelimiter: ']'
                });
         */
        });

        done();
    }

    install() {
        var done = this.async();
        this.spawnCommand('dotnet', ['test'], { 'cwd': `${this.props.name.toLowerCase()}-service/` })
            .on('error', function (err) {
                done(err);
            })
    }
};