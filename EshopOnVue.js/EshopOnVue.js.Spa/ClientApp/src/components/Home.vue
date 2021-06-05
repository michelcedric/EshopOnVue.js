<template>
    <section class="esh-catalog-hero">
        <div class="container">
            <img class="esh-catalog-title" src="../assets/main_banner_text.png" />
        </div>
    </section>
    <section class="esh-catalog-filters">
        <div class="container">
           
        </div>
    </section>


</template>

<script>
export default {
  name: 'Home',
  props: {
    msg: String
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
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
