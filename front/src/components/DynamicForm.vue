<template>
  <validation-observer v-slot="{ handleSubmit }">
    <b-form @submit.prevent="handleSubmit(onSubmit)">
      <b-row>
        <b-col
          :md="element.md"
          :offset-md="element.offsetMd"
          v-for="element in schema.elements"
          :key="element.key"
        >
          <validation-provider :rules="element.validations" v-slot="{ errors }">
            <component
              :is="element.component"
              class="mt-3"
              :class="{'is-invalid': errors[0] }"
              :value="element.value"
              :placeholder="element.placeholder"
              :selected="element.selected"
              :options="element.options"
              :min="element.min"
              :readonly="element.readonly"
              :today-button="element.todayButton"
              :reset-button="element.resetButton"
              :close-button="element.closeButton"
              :locale="element.locale"
              @input="$emit('input', { key: element.key, value: $event })"
              @change="$emit('change', { key: element.key, value: $event })"
            />
            <span style="color: red">{{ errors[0] }}</span>
          </validation-provider>
        </b-col>
      </b-row>
      <b-row>
        <b-col md="4" offset-md="4" class="mt-4">
          <b-button type="submit" variant="primary">{{schema.bSave}}</b-button>
          <b-button @click="$router.go(-1)">{{schema.bBack}}</b-button>
        </b-col>
      </b-row>
    </b-form>
  </validation-observer>
</template>

<script>
import { ValidationProvider, ValidationObserver, extend } from "vee-validate";
import { required, max } from "vee-validate/dist/rules";

extend("required", {
  ...required,
  message: "Este campo es requerido.",
});
extend("max", {
  ...max,
  message: "Este campo ha superado el maximo permitido.",
});

export default {
  name: "DynamicForm",
  components: {
    ValidationProvider,
    ValidationObserver,
  },
  props: {
    schema: {
      type: Object,
      default: () => [],
    },
  },
  data() {
    return {};
  },
  methods: {
    onSubmit() {
      this.$emit("submit", {});
    },
  },
};
</script>