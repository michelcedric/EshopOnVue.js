<template>
    <section class="esh-catalog-hero">
        <div class="container">
            <img class="esh-catalog-title" src="../assets/main_banner_text.png" />
        </div>
    </section>
    <section class="esh-catalog-filters">
        <div class="container">
            <p v-if="!catalogItems"><em>Loading...</em></p>
            <div class="esh-catalog-items row">                
                <div class="esh-catalog-item col-md-4" v-for="catalogItem of catalogItems" v-bind:key="catalogItem">
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
        </div>
    </section>
</template>

<script>   
    import axios from 'axios'
    export default {
        name: "FetchData",
        data() {
            return {
                catalogItems: []
            }
        },
        methods: {
            formatPrice(value) {
                let val = (value / 1).toFixed(2).replace('.', ',')
                return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".")
            },
            getCatalogItems() {
                axios.get('api/catalog')
                    .then((response) => {
                        this.catalogItems = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            }
        },
        mounted() {
            this.getCatalogItems();
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
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
    .esh-catalog-name {
        font-size: 1rem;
        font-weight: 300;
        margin-top: .5rem;
        text-align: center;
        text-transform: uppercase;
    }
    .esh-catalog-items {
        margin-top: 1rem;
    }

    .esh-catalog-item {
        margin-bottom: 1.5rem;
        text-align: center;
        width: 33%;
        display: inline-block;
        float: none !important;
    }
    .esh-catalog-price {
        font-size: 28px;
        font-weight: 900;
        text-align: center;
    }

        .esh-catalog-price::after {
            content: '\20AC';
        }

    @media screen and (max-width: 1024px) {
        .esh-catalog-item {
            width: 50%;
        }
    }

    @media screen and (max-width: 768px) {
        .esh-catalog-item {
            width: 100%;
        }
    }
    .esh-catalog-hero {
        background-image: url("../assets/main_banner.png");
        background-size: cover;
        height: 260px;
        width: 100%;
    }
    .esh-catalog-filter {
        -webkit-appearance: none;
        background-color: transparent;
        border-color: #00d9cc;
        color: #FFFFFF;
        cursor: pointer;
        margin-right: 1rem;
        margin-top: .5rem;
        min-width: 140px;
        outline-color: #83D01B;
        padding-bottom: 0;
        padding-left: 0.5rem;
        padding-right: 0.5rem;
        padding-top: 1.5rem;
    }

        .esh-catalog-filter option {
            background-color: #00A69C;
        }
</style>
