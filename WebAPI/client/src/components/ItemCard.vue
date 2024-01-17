<style lang="scss">
@import "@/assets/main.scss";

.item-card {
    padding: 8px;
}

.item-card .card {
    border: none;
    @include shadow-1;
}

.item-card .card-body {
    text-align: center;
    font-size: large;
    padding: 8px;
}
</style>

<template>
    <div class="item-card">
        <div class="card">
            <img src="/images/mock/asian.jpg" class="card-img-top" />
            <div class="card-body">
                Азиатская кухня
            </div>
        </div>
    </div>
</template>
