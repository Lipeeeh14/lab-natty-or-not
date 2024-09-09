<script>
import axios from 'axios';

export default {
  data() {
    return {
      request: {
        ingrediente: ''
      },
      result: '',
    };
  },
  methods: {
    async postReceita() {
      try {
        const response = await axios.post('https://localhost:44365/gerar-receita', this.request)
        this.result = response.data.resposta;
      } catch (error) {
        console.error('Erro: ', error);
        this.result = 'Erro ao obter a receita.'
      }
    }
  }
}
</script>

<template>
  <header>
    <h1>Guia de Receitas</h1>
  </header>

  <main>
    <form @submit.prevent="postReceita">
      <div class="row input-data">
        <div class="col">
          <input type="text" v-model="request.ingrediente" class="form-control" placeholder="Ingrediente" aria-label="Ingrediente" aria-describedby="basic-addon1">
          <button type="submit" class="btn btn-primary">Gerar Receita</button>
        </div>    
      </div>
    </form>

    <div class="row">
      <div class="col" v-html="result"></div>
    </div>
  </main>
</template>

<style scoped>
.input-data {
    margin: 2rem;
}

input {
  margin-bottom: 1rem;
}
</style>
