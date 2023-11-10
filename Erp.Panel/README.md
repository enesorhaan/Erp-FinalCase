# Final Project - ERP Panel 

This panel application is an Angular layout project created for Erp.Api endpoints. 

## Summary

<p>
    The services and modules created for CRUD operations for the methods in Api are listed below.
    <ul>
        <li><strong>Environment</strong> has been created file containing used configuration information such as apiUrl and httoOption.</li>
        <li><strong>Auth and auth-guard services</strong> have been created for JWT Token authorization.</li>
        <li><strong>Storage Service</strong> was written to store token information in storage.</li>
        <li><strong>Token.interceptor </strong> was created to automatically create the token information stored in Storage within each request.</li>
        <li><strong>Modules</strong> for each controller in the API are created under the views folder. Adding, listing and editing <strong>Components</strong> corresponding to these modules are also included in the relevant modules.</li>
        <li><strong>The services that feed the components</strong> in each module are created under the services folder.</li>
    <ul>
</p>
<p>
    You can access the endpoint document for Erp.Api from the Postman document link below.
</p>


<div>
    <strong>Erp.Api Endpoints Postman</strong>: <a href="https://documenter.getpostman.com/view/29567242/2s9YXk2fj3">documenter.getpostman.com</a>
</div>

## Quick Start

- Clone the repo: `git clone https://github.com/enesorhaan/VakifBank-FinalCase.git`
- Use the under-folder: Erp.Panel

#### <i>Prerequisites</i>
Before you begin, make sure your development environment includes `Node.js®` and an `npm` package manager.

###### Node.js
[**Angular 16**](https://angular.io/guide/what-is-angular) requires `Node.js` LTS version `^16.14` or `^18.10`.

- To check your version, run `node -v` in a terminal/console window.
- To get `Node.js`, go to [nodejs.org](https://nodejs.org/).

###### Angular CLI
Install the Angular CLI globally using a terminal/console window.
```bash
npm install -g @angular/cli
```

### Installation for node_module (Before run program)

``` bash
$ npm install
```

### Basic usage

``` bash
# dev server with hot reload at http://localhost:4200
$ ng serve
```

Navigate to [http://localhost:4200](http://localhost:4200). The app will automatically reload if you change any of the source files.

#### Build

Run `build` to build the project. The build artifacts will be stored in the `dist/` directory.

```bash
# build for production with minification
$ ng build
```
## What's included

Within the download you'll find the following directories and files, logically grouping common assets and providing both compiled and minified variations. You'll see something like this:

```
coreui-free-angular-admin-template
├── src/                         # project root
│   ├── app/                     # main app directory
|   │   ├── containers/          # layout containers
|   |   │   └── default-layout/  # layout containers
|   |   |       └── _nav.js      # sidebar navigation config
|   │   ├── icons/               # icons set for the app
|   │   ├── views/               # application views
|   │   ├── helpers/             # api token handler
|   │   └── services/            # api endpoint services
│   ├── assets/                  # images, icons, etc.
│   ├── environments/            # configuration or a set of rules
│   ├── scss/                    # scss styles
│   └── index.html               # html template
│
├── angular.json
├── README.md
└── package.json
```

## Documentation

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 15.0.0.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI Overview and Command Reference](https://angular.io/cli) page.



