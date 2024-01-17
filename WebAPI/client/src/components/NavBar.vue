<script setup>
import { RouterLink } from 'vue-router'
</script>

<style lang="scss">
@import "@/assets/main.scss";

.navbar-brand img {
    margin-right: 8px;
    width: 24px;
    height: 24px;
}

.header {
    background-color: #fff;
    @include shadow-1;
}
</style>

<template>
    <header class="header">
        <nav class="navbar navbar-expand-sm bg-body-tertiary">
            <div class="container">
                <a class="navbar-brand" href="#">
                    <img src="/images/icon.png"/>
                    Cookbook
                </a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse"
                    data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false"
                    aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav me-auto mb-2 mb-sm-0">
                        <li class="nav-item">
                            <RouterLink class="nav-link" to="/">Рецепты</RouterLink>
                        </li>
                        <li class="nav-item">
                            <RouterLink class="nav-link" to="/">Меню</RouterLink>
                        </li>
                        <li class="nav-item">
                            <RouterLink class="nav-link" to="/">Список покупок</RouterLink>
                        </li>
                    </ul>
                    <form class="d-flex" role="search">
                        <RouterLink class="btn btn-primary" to="/login">Войти</RouterLink>
                    </form>
                </div>
            </div>
    </nav>
</header></template>
