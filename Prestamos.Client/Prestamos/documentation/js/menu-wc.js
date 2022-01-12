'use strict';

customElements.define('compodoc-menu', class extends HTMLElement {
    constructor() {
        super();
        this.isNormalMode = this.getAttribute('mode') === 'normal';
    }

    connectedCallback() {
        this.render(this.isNormalMode);
    }

    render(isNormalMode) {
        let tp = lithtml.html(`
        <nav>
            <ul class="list">
                <li class="title">
                    <a href="index.html" data-type="index-link">prestamos documentation</a>
                </li>

                <li class="divider"></li>
                ${ isNormalMode ? `` : '' }
                <li class="chapter">
                    <a data-type="chapter-link" href="index.html"><span class="icon ion-ios-home"></span>Getting started</a>
                    <ul class="links">
                        <li class="link">
                            <a href="overview.html" data-type="chapter-link">
                                <span class="icon ion-ios-keypad"></span>Overview
                            </a>
                        </li>
                        <li class="link">
                            <a href="index.html" data-type="chapter-link">
                                <span class="icon ion-ios-paper"></span>README
                            </a>
                        </li>
                    </ul>
                </li>
                    <li class="chapter modules">
                        <a data-type="chapter-link" href="modules.html">
                            <div class="menu-toggler linked" data-toggle="collapse" ${ isNormalMode ?
                                'data-target="#modules-links"' : 'data-target="#xs-modules-links"' }>
                                <span class="icon ion-ios-archive"></span>
                                <span class="link-name">Modules</span>
                                <span class="icon ion-ios-arrow-down"></span>
                            </div>
                        </a>
                        <ul class="links collapse " ${ isNormalMode ? 'id="modules-links"' : 'id="xs-modules-links"' }>
                            <li class="link">
                                <a href="modules/AdminModule.html" data-type="entity-link" >AdminModule</a>
                                    <li class="chapter inner">
                                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ?
                                            'data-target="#components-links-module-AdminModule-b158941505cccc4787afb8850b22f23e975f16782bea54d69c7a2e3e4d7e25eeb4b4217e45f1398b4cfe56c76c04bfdf00ea39a036647e7da879a8639bdaadd5"' : 'data-target="#xs-components-links-module-AdminModule-b158941505cccc4787afb8850b22f23e975f16782bea54d69c7a2e3e4d7e25eeb4b4217e45f1398b4cfe56c76c04bfdf00ea39a036647e7da879a8639bdaadd5"' }>
                                            <span class="icon ion-md-cog"></span>
                                            <span>Components</span>
                                            <span class="icon ion-ios-arrow-down"></span>
                                        </div>
                                        <ul class="links collapse" ${ isNormalMode ? 'id="components-links-module-AdminModule-b158941505cccc4787afb8850b22f23e975f16782bea54d69c7a2e3e4d7e25eeb4b4217e45f1398b4cfe56c76c04bfdf00ea39a036647e7da879a8639bdaadd5"' :
                                            'id="xs-components-links-module-AdminModule-b158941505cccc4787afb8850b22f23e975f16782bea54d69c7a2e3e4d7e25eeb4b4217e45f1398b4cfe56c76c04bfdf00ea39a036647e7da879a8639bdaadd5"' }>
                                            <li class="link">
                                                <a href="components/AdminComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >AdminComponent</a>
                                            </li>
                                        </ul>
                                    </li>
                            </li>
                            <li class="link">
                                <a href="modules/AdminRoutingModule.html" data-type="entity-link" >AdminRoutingModule</a>
                            </li>
                            <li class="link">
                                <a href="modules/AppModule.html" data-type="entity-link" >AppModule</a>
                                    <li class="chapter inner">
                                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ?
                                            'data-target="#components-links-module-AppModule-e08e9752c9a868a4eb1fe2026e9f2c0e94b5cd8a58f5f906c02ff90b618aa83865fa04b0aad4153a4cf9c61a6c4a72f029c0440eddbee4192254831af87707ae"' : 'data-target="#xs-components-links-module-AppModule-e08e9752c9a868a4eb1fe2026e9f2c0e94b5cd8a58f5f906c02ff90b618aa83865fa04b0aad4153a4cf9c61a6c4a72f029c0440eddbee4192254831af87707ae"' }>
                                            <span class="icon ion-md-cog"></span>
                                            <span>Components</span>
                                            <span class="icon ion-ios-arrow-down"></span>
                                        </div>
                                        <ul class="links collapse" ${ isNormalMode ? 'id="components-links-module-AppModule-e08e9752c9a868a4eb1fe2026e9f2c0e94b5cd8a58f5f906c02ff90b618aa83865fa04b0aad4153a4cf9c61a6c4a72f029c0440eddbee4192254831af87707ae"' :
                                            'id="xs-components-links-module-AppModule-e08e9752c9a868a4eb1fe2026e9f2c0e94b5cd8a58f5f906c02ff90b618aa83865fa04b0aad4153a4cf9c61a6c4a72f029c0440eddbee4192254831af87707ae"' }>
                                            <li class="link">
                                                <a href="components/AppComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >AppComponent</a>
                                            </li>
                                        </ul>
                                    </li>
                            </li>
                            <li class="link">
                                <a href="modules/AppRoutingModule.html" data-type="entity-link" >AppRoutingModule</a>
                            </li>
                            <li class="link">
                                <a href="modules/AuthModule.html" data-type="entity-link" >AuthModule</a>
                            </li>
                            <li class="link">
                                <a href="modules/AuthRoutingModule.html" data-type="entity-link" >AuthRoutingModule</a>
                            </li>
                            <li class="link">
                                <a href="modules/ClientesModule.html" data-type="entity-link" >ClientesModule</a>
                                    <li class="chapter inner">
                                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ?
                                            'data-target="#components-links-module-ClientesModule-36c2ab37d4c336609dada8cfc9c6e8470d175099d2b89fe36b46015eb87d9b9674b0368e9ae287130891ba9d289807985f4617ded65ea0890ceaf2b346fae002"' : 'data-target="#xs-components-links-module-ClientesModule-36c2ab37d4c336609dada8cfc9c6e8470d175099d2b89fe36b46015eb87d9b9674b0368e9ae287130891ba9d289807985f4617ded65ea0890ceaf2b346fae002"' }>
                                            <span class="icon ion-md-cog"></span>
                                            <span>Components</span>
                                            <span class="icon ion-ios-arrow-down"></span>
                                        </div>
                                        <ul class="links collapse" ${ isNormalMode ? 'id="components-links-module-ClientesModule-36c2ab37d4c336609dada8cfc9c6e8470d175099d2b89fe36b46015eb87d9b9674b0368e9ae287130891ba9d289807985f4617ded65ea0890ceaf2b346fae002"' :
                                            'id="xs-components-links-module-ClientesModule-36c2ab37d4c336609dada8cfc9c6e8470d175099d2b89fe36b46015eb87d9b9674b0368e9ae287130891ba9d289807985f4617ded65ea0890ceaf2b346fae002"' }>
                                            <li class="link">
                                                <a href="components/AgregarClientesComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >AgregarClientesComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/ClientesComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >ClientesComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/DetalleClienteComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >DetalleClienteComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/EditarClientesComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >EditarClientesComponent</a>
                                            </li>
                                        </ul>
                                    </li>
                            </li>
                            <li class="link">
                                <a href="modules/ClientesRoutingModule.html" data-type="entity-link" >ClientesRoutingModule</a>
                            </li>
                            <li class="link">
                                <a href="modules/ConfiguracionModule.html" data-type="entity-link" >ConfiguracionModule</a>
                                    <li class="chapter inner">
                                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ?
                                            'data-target="#components-links-module-ConfiguracionModule-443e2ccbad373c491f88b04570d01d2f4e6ed7fef4160ad14b8b9fa7c3a1fb73b36e611739ccc1cdd6548499c02b6aea5b5b216322f27fea07f3e8fff00b574f"' : 'data-target="#xs-components-links-module-ConfiguracionModule-443e2ccbad373c491f88b04570d01d2f4e6ed7fef4160ad14b8b9fa7c3a1fb73b36e611739ccc1cdd6548499c02b6aea5b5b216322f27fea07f3e8fff00b574f"' }>
                                            <span class="icon ion-md-cog"></span>
                                            <span>Components</span>
                                            <span class="icon ion-ios-arrow-down"></span>
                                        </div>
                                        <ul class="links collapse" ${ isNormalMode ? 'id="components-links-module-ConfiguracionModule-443e2ccbad373c491f88b04570d01d2f4e6ed7fef4160ad14b8b9fa7c3a1fb73b36e611739ccc1cdd6548499c02b6aea5b5b216322f27fea07f3e8fff00b574f"' :
                                            'id="xs-components-links-module-ConfiguracionModule-443e2ccbad373c491f88b04570d01d2f4e6ed7fef4160ad14b8b9fa7c3a1fb73b36e611739ccc1cdd6548499c02b6aea5b5b216322f27fea07f3e8fff00b574f"' }>
                                            <li class="link">
                                                <a href="components/ConfiguracionComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >ConfiguracionComponent</a>
                                            </li>
                                        </ul>
                                    </li>
                            </li>
                            <li class="link">
                                <a href="modules/ConfiguracionRoutingModule.html" data-type="entity-link" >ConfiguracionRoutingModule</a>
                            </li>
                            <li class="link">
                                <a href="modules/CrearPrestamosModule.html" data-type="entity-link" >CrearPrestamosModule</a>
                                    <li class="chapter inner">
                                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ?
                                            'data-target="#components-links-module-CrearPrestamosModule-1a9525d6327ad9fc9e25f5d83f0e0a4cd9257d9a35cfd8c9cbe4c535d72ba60ddd25841a1d1bd53141c90d2d0fcd0b9b3a8a9ffd0d75e610a0fc838252d70c5d"' : 'data-target="#xs-components-links-module-CrearPrestamosModule-1a9525d6327ad9fc9e25f5d83f0e0a4cd9257d9a35cfd8c9cbe4c535d72ba60ddd25841a1d1bd53141c90d2d0fcd0b9b3a8a9ffd0d75e610a0fc838252d70c5d"' }>
                                            <span class="icon ion-md-cog"></span>
                                            <span>Components</span>
                                            <span class="icon ion-ios-arrow-down"></span>
                                        </div>
                                        <ul class="links collapse" ${ isNormalMode ? 'id="components-links-module-CrearPrestamosModule-1a9525d6327ad9fc9e25f5d83f0e0a4cd9257d9a35cfd8c9cbe4c535d72ba60ddd25841a1d1bd53141c90d2d0fcd0b9b3a8a9ffd0d75e610a0fc838252d70c5d"' :
                                            'id="xs-components-links-module-CrearPrestamosModule-1a9525d6327ad9fc9e25f5d83f0e0a4cd9257d9a35cfd8c9cbe4c535d72ba60ddd25841a1d1bd53141c90d2d0fcd0b9b3a8a9ffd0d75e610a0fc838252d70c5d"' }>
                                            <li class="link">
                                                <a href="components/ConcederPrestamoComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >ConcederPrestamoComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/FacturaComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >FacturaComponent</a>
                                            </li>
                                        </ul>
                                    </li>
                            </li>
                            <li class="link">
                                <a href="modules/CrearPrestamosRoutingModule.html" data-type="entity-link" >CrearPrestamosRoutingModule</a>
                            </li>
                            <li class="link">
                                <a href="modules/DashboardModule.html" data-type="entity-link" >DashboardModule</a>
                                    <li class="chapter inner">
                                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ?
                                            'data-target="#components-links-module-DashboardModule-1c1e712061418fc5492651d711e465924242871b6d7f41ecc5bb71fa9b08ffb1e211d002e51e90b0a470f256186d908d5281535b04cee27a04e80503d4d8ac39"' : 'data-target="#xs-components-links-module-DashboardModule-1c1e712061418fc5492651d711e465924242871b6d7f41ecc5bb71fa9b08ffb1e211d002e51e90b0a470f256186d908d5281535b04cee27a04e80503d4d8ac39"' }>
                                            <span class="icon ion-md-cog"></span>
                                            <span>Components</span>
                                            <span class="icon ion-ios-arrow-down"></span>
                                        </div>
                                        <ul class="links collapse" ${ isNormalMode ? 'id="components-links-module-DashboardModule-1c1e712061418fc5492651d711e465924242871b6d7f41ecc5bb71fa9b08ffb1e211d002e51e90b0a470f256186d908d5281535b04cee27a04e80503d4d8ac39"' :
                                            'id="xs-components-links-module-DashboardModule-1c1e712061418fc5492651d711e465924242871b6d7f41ecc5bb71fa9b08ffb1e211d002e51e90b0a470f256186d908d5281535b04cee27a04e80503d4d8ac39"' }>
                                            <li class="link">
                                                <a href="components/DashboardComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >DashboardComponent</a>
                                            </li>
                                        </ul>
                                    </li>
                            </li>
                            <li class="link">
                                <a href="modules/DashboardRoutingModule.html" data-type="entity-link" >DashboardRoutingModule</a>
                            </li>
                            <li class="link">
                                <a href="modules/ErrorModule.html" data-type="entity-link" >ErrorModule</a>
                                    <li class="chapter inner">
                                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ?
                                            'data-target="#components-links-module-ErrorModule-09b2d54dd2f1b2d73e23c8c6c6ce977c5a8e045febb1a37e55c8bc3abc49a4f2d2e0b5f241aa8cd35fe5d3520feb29235d23c2e13b0d4c3bc950c1c320068937"' : 'data-target="#xs-components-links-module-ErrorModule-09b2d54dd2f1b2d73e23c8c6c6ce977c5a8e045febb1a37e55c8bc3abc49a4f2d2e0b5f241aa8cd35fe5d3520feb29235d23c2e13b0d4c3bc950c1c320068937"' }>
                                            <span class="icon ion-md-cog"></span>
                                            <span>Components</span>
                                            <span class="icon ion-ios-arrow-down"></span>
                                        </div>
                                        <ul class="links collapse" ${ isNormalMode ? 'id="components-links-module-ErrorModule-09b2d54dd2f1b2d73e23c8c6c6ce977c5a8e045febb1a37e55c8bc3abc49a4f2d2e0b5f241aa8cd35fe5d3520feb29235d23c2e13b0d4c3bc950c1c320068937"' :
                                            'id="xs-components-links-module-ErrorModule-09b2d54dd2f1b2d73e23c8c6c6ce977c5a8e045febb1a37e55c8bc3abc49a4f2d2e0b5f241aa8cd35fe5d3520feb29235d23c2e13b0d4c3bc950c1c320068937"' }>
                                            <li class="link">
                                                <a href="components/ErrorComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >ErrorComponent</a>
                                            </li>
                                        </ul>
                                    </li>
                            </li>
                            <li class="link">
                                <a href="modules/ErrorRoutingModule.html" data-type="entity-link" >ErrorRoutingModule</a>
                            </li>
                            <li class="link">
                                <a href="modules/LoginModule.html" data-type="entity-link" >LoginModule</a>
                                    <li class="chapter inner">
                                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ?
                                            'data-target="#components-links-module-LoginModule-4613a9267861c7d3910225256bcacd99f52b9c88de3c0a66b1ffeb0a4c9ef53cf4aa1faa776449a2868c5e73e16ff386a3d34874f0e3842869dd05eeae792077"' : 'data-target="#xs-components-links-module-LoginModule-4613a9267861c7d3910225256bcacd99f52b9c88de3c0a66b1ffeb0a4c9ef53cf4aa1faa776449a2868c5e73e16ff386a3d34874f0e3842869dd05eeae792077"' }>
                                            <span class="icon ion-md-cog"></span>
                                            <span>Components</span>
                                            <span class="icon ion-ios-arrow-down"></span>
                                        </div>
                                        <ul class="links collapse" ${ isNormalMode ? 'id="components-links-module-LoginModule-4613a9267861c7d3910225256bcacd99f52b9c88de3c0a66b1ffeb0a4c9ef53cf4aa1faa776449a2868c5e73e16ff386a3d34874f0e3842869dd05eeae792077"' :
                                            'id="xs-components-links-module-LoginModule-4613a9267861c7d3910225256bcacd99f52b9c88de3c0a66b1ffeb0a4c9ef53cf4aa1faa776449a2868c5e73e16ff386a3d34874f0e3842869dd05eeae792077"' }>
                                            <li class="link">
                                                <a href="components/LoginComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >LoginComponent</a>
                                            </li>
                                        </ul>
                                    </li>
                            </li>
                            <li class="link">
                                <a href="modules/LoginRoutingModule.html" data-type="entity-link" >LoginRoutingModule</a>
                            </li>
                            <li class="link">
                                <a href="modules/PagarPrestamosModule.html" data-type="entity-link" >PagarPrestamosModule</a>
                                    <li class="chapter inner">
                                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ?
                                            'data-target="#components-links-module-PagarPrestamosModule-537fdd7caf4144a782028608d885d9a05f47a35208b8a9865d9257e0e615a91b107972baae9150289f332428b6e7a0938e4ccf912d84188e08497f6421c93573"' : 'data-target="#xs-components-links-module-PagarPrestamosModule-537fdd7caf4144a782028608d885d9a05f47a35208b8a9865d9257e0e615a91b107972baae9150289f332428b6e7a0938e4ccf912d84188e08497f6421c93573"' }>
                                            <span class="icon ion-md-cog"></span>
                                            <span>Components</span>
                                            <span class="icon ion-ios-arrow-down"></span>
                                        </div>
                                        <ul class="links collapse" ${ isNormalMode ? 'id="components-links-module-PagarPrestamosModule-537fdd7caf4144a782028608d885d9a05f47a35208b8a9865d9257e0e615a91b107972baae9150289f332428b6e7a0938e4ccf912d84188e08497f6421c93573"' :
                                            'id="xs-components-links-module-PagarPrestamosModule-537fdd7caf4144a782028608d885d9a05f47a35208b8a9865d9257e0e615a91b107972baae9150289f332428b6e7a0938e4ccf912d84188e08497f6421c93573"' }>
                                            <li class="link">
                                                <a href="components/PagarPrestamoComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >PagarPrestamoComponent</a>
                                            </li>
                                        </ul>
                                    </li>
                            </li>
                            <li class="link">
                                <a href="modules/PagarPrestamosRoutingModule.html" data-type="entity-link" >PagarPrestamosRoutingModule</a>
                            </li>
                            <li class="link">
                                <a href="modules/PrestamosModule.html" data-type="entity-link" >PrestamosModule</a>
                                    <li class="chapter inner">
                                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ?
                                            'data-target="#components-links-module-PrestamosModule-32c8d86210db1bed466000c4e559900bbbd9705b7308e2207a7e35737b0e9633020fd9427873936e3604942dbe5006694559e9280906e6aaba2a38e191ac748d"' : 'data-target="#xs-components-links-module-PrestamosModule-32c8d86210db1bed466000c4e559900bbbd9705b7308e2207a7e35737b0e9633020fd9427873936e3604942dbe5006694559e9280906e6aaba2a38e191ac748d"' }>
                                            <span class="icon ion-md-cog"></span>
                                            <span>Components</span>
                                            <span class="icon ion-ios-arrow-down"></span>
                                        </div>
                                        <ul class="links collapse" ${ isNormalMode ? 'id="components-links-module-PrestamosModule-32c8d86210db1bed466000c4e559900bbbd9705b7308e2207a7e35737b0e9633020fd9427873936e3604942dbe5006694559e9280906e6aaba2a38e191ac748d"' :
                                            'id="xs-components-links-module-PrestamosModule-32c8d86210db1bed466000c4e559900bbbd9705b7308e2207a7e35737b0e9633020fd9427873936e3604942dbe5006694559e9280906e6aaba2a38e191ac748d"' }>
                                            <li class="link">
                                                <a href="components/DetallePrestamoComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >DetallePrestamoComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/PrestamosComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >PrestamosComponent</a>
                                            </li>
                                        </ul>
                                    </li>
                            </li>
                            <li class="link">
                                <a href="modules/PrestamosRoutingModule.html" data-type="entity-link" >PrestamosRoutingModule</a>
                            </li>
                            <li class="link">
                                <a href="modules/SharedModule.html" data-type="entity-link" >SharedModule</a>
                                    <li class="chapter inner">
                                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ?
                                            'data-target="#components-links-module-SharedModule-de08cd8e7bf1dab49e90a813dbcbe256b290237d7593f387a838a7889e58a6d6c69f9e35ea073d7fcb5e399efefba04423df2d4f208b5fb05f6d90fbb2ce5d69"' : 'data-target="#xs-components-links-module-SharedModule-de08cd8e7bf1dab49e90a813dbcbe256b290237d7593f387a838a7889e58a6d6c69f9e35ea073d7fcb5e399efefba04423df2d4f208b5fb05f6d90fbb2ce5d69"' }>
                                            <span class="icon ion-md-cog"></span>
                                            <span>Components</span>
                                            <span class="icon ion-ios-arrow-down"></span>
                                        </div>
                                        <ul class="links collapse" ${ isNormalMode ? 'id="components-links-module-SharedModule-de08cd8e7bf1dab49e90a813dbcbe256b290237d7593f387a838a7889e58a6d6c69f9e35ea073d7fcb5e399efefba04423df2d4f208b5fb05f6d90fbb2ce5d69"' :
                                            'id="xs-components-links-module-SharedModule-de08cd8e7bf1dab49e90a813dbcbe256b290237d7593f387a838a7889e58a6d6c69f9e35ea073d7fcb5e399efefba04423df2d4f208b5fb05f6d90fbb2ce5d69"' }>
                                            <li class="link">
                                                <a href="components/BuscadorComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >BuscadorComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/FooterComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >FooterComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/HeaderComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >HeaderComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/IconoComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >IconoComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/MenuComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >MenuComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/PaginacionComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >PaginacionComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/SpinnerComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >SpinnerComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/TableComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >TableComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/ToastrComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >ToastrComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/VentanaConfirmacionComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >VentanaConfirmacionComponent</a>
                                            </li>
                                        </ul>
                                    </li>
                                <li class="chapter inner">
                                    <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ?
                                        'data-target="#directives-links-module-SharedModule-de08cd8e7bf1dab49e90a813dbcbe256b290237d7593f387a838a7889e58a6d6c69f9e35ea073d7fcb5e399efefba04423df2d4f208b5fb05f6d90fbb2ce5d69"' : 'data-target="#xs-directives-links-module-SharedModule-de08cd8e7bf1dab49e90a813dbcbe256b290237d7593f387a838a7889e58a6d6c69f9e35ea073d7fcb5e399efefba04423df2d4f208b5fb05f6d90fbb2ce5d69"' }>
                                        <span class="icon ion-md-code-working"></span>
                                        <span>Directives</span>
                                        <span class="icon ion-ios-arrow-down"></span>
                                    </div>
                                    <ul class="links collapse" ${ isNormalMode ? 'id="directives-links-module-SharedModule-de08cd8e7bf1dab49e90a813dbcbe256b290237d7593f387a838a7889e58a6d6c69f9e35ea073d7fcb5e399efefba04423df2d4f208b5fb05f6d90fbb2ce5d69"' :
                                        'id="xs-directives-links-module-SharedModule-de08cd8e7bf1dab49e90a813dbcbe256b290237d7593f387a838a7889e58a6d6c69f9e35ea073d7fcb5e399efefba04423df2d4f208b5fb05f6d90fbb2ce5d69"' }>
                                        <li class="link">
                                            <a href="directives/ColorFilaEstatusCrediticioClienteDirective.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >ColorFilaEstatusCrediticioClienteDirective</a>
                                        </li>
                                        <li class="link">
                                            <a href="directives/ColorFilaEstatusPrestamoClienteDirective.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >ColorFilaEstatusPrestamoClienteDirective</a>
                                        </li>
                                        <li class="link">
                                            <a href="directives/InicialesDirective.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >InicialesDirective</a>
                                        </li>
                                    </ul>
                                </li>
                                    <li class="chapter inner">
                                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ?
                                            'data-target="#pipes-links-module-SharedModule-de08cd8e7bf1dab49e90a813dbcbe256b290237d7593f387a838a7889e58a6d6c69f9e35ea073d7fcb5e399efefba04423df2d4f208b5fb05f6d90fbb2ce5d69"' : 'data-target="#xs-pipes-links-module-SharedModule-de08cd8e7bf1dab49e90a813dbcbe256b290237d7593f387a838a7889e58a6d6c69f9e35ea073d7fcb5e399efefba04423df2d4f208b5fb05f6d90fbb2ce5d69"' }>
                                            <span class="icon ion-md-add"></span>
                                            <span>Pipes</span>
                                            <span class="icon ion-ios-arrow-down"></span>
                                        </div>
                                        <ul class="links collapse" ${ isNormalMode ? 'id="pipes-links-module-SharedModule-de08cd8e7bf1dab49e90a813dbcbe256b290237d7593f387a838a7889e58a6d6c69f9e35ea073d7fcb5e399efefba04423df2d4f208b5fb05f6d90fbb2ce5d69"' :
                                            'id="xs-pipes-links-module-SharedModule-de08cd8e7bf1dab49e90a813dbcbe256b290237d7593f387a838a7889e58a6d6c69f9e35ea073d7fcb5e399efefba04423df2d4f208b5fb05f6d90fbb2ce5d69"' }>
                                            <li class="link">
                                                <a href="pipes/EstatusCrediticioToStringPipe.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >EstatusCrediticioToStringPipe</a>
                                            </li>
                                            <li class="link">
                                                <a href="pipes/EstatusPrestamoToStringPipe.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >EstatusPrestamoToStringPipe</a>
                                            </li>
                                            <li class="link">
                                                <a href="pipes/PeriodoPagoToStringPipe.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >PeriodoPagoToStringPipe</a>
                                            </li>
                                            <li class="link">
                                                <a href="pipes/RolToStringPipe.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >RolToStringPipe</a>
                                            </li>
                                        </ul>
                                    </li>
                            </li>
                            <li class="link">
                                <a href="modules/UsuariosModule.html" data-type="entity-link" >UsuariosModule</a>
                                    <li class="chapter inner">
                                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ?
                                            'data-target="#components-links-module-UsuariosModule-ea959c4b12a3d9dcbf1c0907ac9f4b5b772c041a49f811020f66b0b0c3a808dd24e500b8be78eea4120f4f787a51252edc2137dfb1300a024c7afca8d778afc9"' : 'data-target="#xs-components-links-module-UsuariosModule-ea959c4b12a3d9dcbf1c0907ac9f4b5b772c041a49f811020f66b0b0c3a808dd24e500b8be78eea4120f4f787a51252edc2137dfb1300a024c7afca8d778afc9"' }>
                                            <span class="icon ion-md-cog"></span>
                                            <span>Components</span>
                                            <span class="icon ion-ios-arrow-down"></span>
                                        </div>
                                        <ul class="links collapse" ${ isNormalMode ? 'id="components-links-module-UsuariosModule-ea959c4b12a3d9dcbf1c0907ac9f4b5b772c041a49f811020f66b0b0c3a808dd24e500b8be78eea4120f4f787a51252edc2137dfb1300a024c7afca8d778afc9"' :
                                            'id="xs-components-links-module-UsuariosModule-ea959c4b12a3d9dcbf1c0907ac9f4b5b772c041a49f811020f66b0b0c3a808dd24e500b8be78eea4120f4f787a51252edc2137dfb1300a024c7afca8d778afc9"' }>
                                            <li class="link">
                                                <a href="components/AgregarUsuarioComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >AgregarUsuarioComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/DetalleUsuarioComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >DetalleUsuarioComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/EditarUsuarioComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >EditarUsuarioComponent</a>
                                            </li>
                                            <li class="link">
                                                <a href="components/UsuariosComponent.html" data-type="entity-link" data-context="sub-entity" data-context-id="modules" >UsuariosComponent</a>
                                            </li>
                                        </ul>
                                    </li>
                            </li>
                            <li class="link">
                                <a href="modules/UsuariosRoutingModule.html" data-type="entity-link" >UsuariosRoutingModule</a>
                            </li>
                </ul>
                </li>
                    <li class="chapter">
                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ? 'data-target="#classes-links"' :
                            'data-target="#xs-classes-links"' }>
                            <span class="icon ion-ios-paper"></span>
                            <span>Classes</span>
                            <span class="icon ion-ios-arrow-down"></span>
                        </div>
                        <ul class="links collapse " ${ isNormalMode ? 'id="classes-links"' : 'id="xs-classes-links"' }>
                            <li class="link">
                                <a href="classes/MyValidations.html" data-type="entity-link" >MyValidations</a>
                            </li>
                            <li class="link">
                                <a href="classes/ValidarCedula.html" data-type="entity-link" >ValidarCedula</a>
                            </li>
                        </ul>
                    </li>
                        <li class="chapter">
                            <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ? 'data-target="#injectables-links"' :
                                'data-target="#xs-injectables-links"' }>
                                <span class="icon ion-md-arrow-round-down"></span>
                                <span>Injectables</span>
                                <span class="icon ion-ios-arrow-down"></span>
                            </div>
                            <ul class="links collapse " ${ isNormalMode ? 'id="injectables-links"' : 'id="xs-injectables-links"' }>
                                <li class="link">
                                    <a href="injectables/AuthService.html" data-type="entity-link" >AuthService</a>
                                </li>
                                <li class="link">
                                    <a href="injectables/ClienteService.html" data-type="entity-link" >ClienteService</a>
                                </li>
                                <li class="link">
                                    <a href="injectables/ConfiguracionService.html" data-type="entity-link" >ConfiguracionService</a>
                                </li>
                                <li class="link">
                                    <a href="injectables/CronogramprestamoPdfService.html" data-type="entity-link" >CronogramprestamoPdfService</a>
                                </li>
                                <li class="link">
                                    <a href="injectables/DashboardService.html" data-type="entity-link" >DashboardService</a>
                                </li>
                                <li class="link">
                                    <a href="injectables/ErrorService.html" data-type="entity-link" >ErrorService</a>
                                </li>
                                <li class="link">
                                    <a href="injectables/LoandingService.html" data-type="entity-link" >LoandingService</a>
                                </li>
                                <li class="link">
                                    <a href="injectables/LocalStorageService.html" data-type="entity-link" >LocalStorageService</a>
                                </li>
                                <li class="link">
                                    <a href="injectables/PagarPrestamoService.html" data-type="entity-link" >PagarPrestamoService</a>
                                </li>
                                <li class="link">
                                    <a href="injectables/PeriodoPagoService.html" data-type="entity-link" >PeriodoPagoService</a>
                                </li>
                                <li class="link">
                                    <a href="injectables/PrestamoService.html" data-type="entity-link" >PrestamoService</a>
                                </li>
                                <li class="link">
                                    <a href="injectables/ToastService.html" data-type="entity-link" >ToastService</a>
                                </li>
                                <li class="link">
                                    <a href="injectables/UsuarioService.html" data-type="entity-link" >UsuarioService</a>
                                </li>
                            </ul>
                        </li>
                    <li class="chapter">
                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ? 'data-target="#interceptors-links"' :
                            'data-target="#xs-interceptors-links"' }>
                            <span class="icon ion-ios-swap"></span>
                            <span>Interceptors</span>
                            <span class="icon ion-ios-arrow-down"></span>
                        </div>
                        <ul class="links collapse " ${ isNormalMode ? 'id="interceptors-links"' : 'id="xs-interceptors-links"' }>
                            <li class="link">
                                <a href="interceptors/ApiKeyInterceptor.html" data-type="entity-link" >ApiKeyInterceptor</a>
                            </li>
                            <li class="link">
                                <a href="interceptors/ApiPrefixInterceptor.html" data-type="entity-link" >ApiPrefixInterceptor</a>
                            </li>
                            <li class="link">
                                <a href="interceptors/JwtInterceptor.html" data-type="entity-link" >JwtInterceptor</a>
                            </li>
                            <li class="link">
                                <a href="interceptors/LoandingInterceptor.html" data-type="entity-link" >LoandingInterceptor</a>
                            </li>
                        </ul>
                    </li>
                    <li class="chapter">
                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ? 'data-target="#guards-links"' :
                            'data-target="#xs-guards-links"' }>
                            <span class="icon ion-ios-lock"></span>
                            <span>Guards</span>
                            <span class="icon ion-ios-arrow-down"></span>
                        </div>
                        <ul class="links collapse " ${ isNormalMode ? 'id="guards-links"' : 'id="xs-guards-links"' }>
                            <li class="link">
                                <a href="guards/AuthGuard.html" data-type="entity-link" >AuthGuard</a>
                            </li>
                            <li class="link">
                                <a href="guards/AuthorizationGuard.html" data-type="entity-link" >AuthorizationGuard</a>
                            </li>
                            <li class="link">
                                <a href="guards/ErrorGuard.html" data-type="entity-link" >ErrorGuard</a>
                            </li>
                        </ul>
                    </li>
                    <li class="chapter">
                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ? 'data-target="#interfaces-links"' :
                            'data-target="#xs-interfaces-links"' }>
                            <span class="icon ion-md-information-circle-outline"></span>
                            <span>Interfaces</span>
                            <span class="icon ion-ios-arrow-down"></span>
                        </div>
                        <ul class="links collapse " ${ isNormalMode ? ' id="interfaces-links"' : 'id="xs-interfaces-links"' }>
                            <li class="link">
                                <a href="interfaces/AddCliente.html" data-type="entity-link" >AddCliente</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/AddDetallePrestamo.html" data-type="entity-link" >AddDetallePrestamo</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/AddDireccion.html" data-type="entity-link" >AddDireccion</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/AddPrestamo.html" data-type="entity-link" >AddPrestamo</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/AddUsuario.html" data-type="entity-link" >AddUsuario</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/ApiResponse.html" data-type="entity-link" >ApiResponse</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/Cliente.html" data-type="entity-link" >Cliente</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/Dashboard.html" data-type="entity-link" >Dashboard</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/DetallePrestamo.html" data-type="entity-link" >DetallePrestamo</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/Direccion.html" data-type="entity-link" >Direccion</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/Empresa.html" data-type="entity-link" >Empresa</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/ErrorModel.html" data-type="entity-link" >ErrorModel</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/EstatusCrediticio.html" data-type="entity-link" >EstatusCrediticio</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/EstatusPrestamo.html" data-type="entity-link" >EstatusPrestamo</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/LoginModel.html" data-type="entity-link" >LoginModel</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/PagedResponse.html" data-type="entity-link" >PagedResponse</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/Pagina.html" data-type="entity-link" >Pagina</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/Pagination.html" data-type="entity-link" >Pagination</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/PeriodoPago.html" data-type="entity-link" >PeriodoPago</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/Prestamo.html" data-type="entity-link" >Prestamo</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/ResultadoBusqueda.html" data-type="entity-link" >ResultadoBusqueda</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/ResultadoBusqueda-1.html" data-type="entity-link" >ResultadoBusqueda</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/Rol.html" data-type="entity-link" >Rol</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/ToastModel.html" data-type="entity-link" >ToastModel</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/UpdateCliente.html" data-type="entity-link" >UpdateCliente</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/UpdateEmpresa.html" data-type="entity-link" >UpdateEmpresa</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/UpdateUsuario.html" data-type="entity-link" >UpdateUsuario</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/UserAuth.html" data-type="entity-link" >UserAuth</a>
                            </li>
                            <li class="link">
                                <a href="interfaces/Usuario.html" data-type="entity-link" >Usuario</a>
                            </li>
                        </ul>
                    </li>
                    <li class="chapter">
                        <div class="simple menu-toggler" data-toggle="collapse" ${ isNormalMode ? 'data-target="#miscellaneous-links"'
                            : 'data-target="#xs-miscellaneous-links"' }>
                            <span class="icon ion-ios-cube"></span>
                            <span>Miscellaneous</span>
                            <span class="icon ion-ios-arrow-down"></span>
                        </div>
                        <ul class="links collapse " ${ isNormalMode ? 'id="miscellaneous-links"' : 'id="xs-miscellaneous-links"' }>
                            <li class="link">
                                <a href="miscellaneous/enumerations.html" data-type="entity-link">Enums</a>
                            </li>
                            <li class="link">
                                <a href="miscellaneous/typealiases.html" data-type="entity-link">Type aliases</a>
                            </li>
                            <li class="link">
                                <a href="miscellaneous/variables.html" data-type="entity-link">Variables</a>
                            </li>
                        </ul>
                    </li>
                    <li class="divider"></li>
                    <li class="copyright">
                        Documentation generated using <a href="https://compodoc.app/" target="_blank">
                            <img data-src="images/compodoc-vectorise.png" class="img-responsive" data-type="compodoc-logo">
                        </a>
                    </li>
            </ul>
        </nav>
        `);
        this.innerHTML = tp.strings;
    }
});