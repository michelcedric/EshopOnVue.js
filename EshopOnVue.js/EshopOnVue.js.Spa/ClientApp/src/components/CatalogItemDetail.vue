<template>
    <div class="esh-catalog-item col-md-4">
        <div class="esh-catalog-name">
            <img class="esh-catalog-thumbnail" :src="catalogItem.pictureUri" />
            <input class="esh-catalog-button" type="submit" value="[ ADD TO BASKET ]" />
            <div class="esh-catalog-name">
                <span>{{ catalogItem.name }}</span>
            </div>
            <div class="esh-catalog-price">
                <span>{{ formatPrice(catalogItem.price) }}</span>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'CatalogItemDetail',
        props: {
            catalogItem: {
                type: Object,
                required: true
            }
        },
        methods: {
            formatPrice(value) {
                let val = (value / 1).toFixed(2).replace('.', ',')
                return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")
            }
        }
    }
</script>

<style scoped>
    .esh-catalog-price {
        font-size: 28px;
        font-weight: 900;
        text-align: center;
    }

    .esh-catalog-price::after {
        content: '\20AC';
    }

    .esh-catalog-name {
        font-size: 1rem;
        font-weight: 300;
        margin-top: .5rem;
        text-align: center;
        text-transform: uppercase;
    }

    .esh-catalog-thumbnail {
        max-width: 370px;
        width: 100%;
    }

    .esh-catalog-button {
        background-color: #83D01B;
        border: 0;
        color: #FFFFFF;
        cursor: pointer;
        font-size: 1rem;
        height: 3rem;
        margin-top: 1rem;
        transition: all 0.35s;
        width: 80%;
    }

    .esh-catalog-button.is-disabled {
        opacity: .5;
        pointer-events: none;
    }

    .esh-catalog-button:hover {
        background-color: #4a760f;
        transition: all 0.35s;
    }
</style>