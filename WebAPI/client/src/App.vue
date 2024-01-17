<script setup>
import { RouterLink, RouterView } from 'vue-router'
import NavBar from './components/NavBar.vue'
import CategoriesMenu from './components/CategoriesMenu.vue'
import RecipesMenu from './components/RecipesMenu.vue'
</script>

<style lang="scss">
@import "@/assets/main.scss";
    .category-card {
        padding: 8px;
    }
    .category-card .card {
        border: none;
        @include shadow-1;
    }
    .category-card .card-body {
        text-align: center;
        font-size: large;
        padding: 8px;
    }
</style>

<template>
    <NavBar />
    <CategoriesMenu/>
    <RecipesMenu/>
</template>
