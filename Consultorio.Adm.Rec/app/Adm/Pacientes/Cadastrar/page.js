"use client";
import Button from "@/app/Components/Button";
import Input from "@/app/Components/Input";
import InputMaks from "@/app/Components/InputMaks";
import Ahref from "@/app/Components/Link";
import React, { useEffect, useState } from "react";
import Alerta from "@/app/Components/Alerta";
import { BuscarPaciente, Cadastro } from "@/Data/Controller/PacienteController";
import Form from "@/Data/cadastro";
import { useRouter, useSearchParams } from "next/navigation";
import Select from "@/app/Components/Select";
import EnumSexo from "@/Helper/EnumSexo";
import { BuscaCep } from "@/Data/Controller/CepController";
import {
  FormatarEndereco,
  RetornarBairro,
  RetornarEndereco,
  RetornarEstado,
  RetornarMunicipio,
  RetornarNumero,
} from "@/Utils/Endereco";
import SelectDatas from "@/app/Components/DatePicker";

function Cadastrar() {
  const [date, setDate] = useState("");
  const [errors, setErros] = useState([]);
  const [typeAlert, settypeAlert] = useState("");
  const router = useRouter();
  const param = useSearchParams();

  useEffect(() => {
    Buscar();
  }, []);

  async function Buscar() {
    if (param.get("paciente") != null) {
      const response = await BuscarPaciente(param.get("paciente"));
      if (response.sucesso == true) {
        id.setValue(response.dados.dados.id);
        guid.setValue(param.get("paciente"));
        nome.setValue(response.dados.dados.nomePaciente);
        cpfEdit.setValue(response.dados.dados.cpf);
        sexo.setValue(response.dados.dados.sexo.toUpperCase());
        endereco.setValue(RetornarEndereco(response.dados.dados.endereco));
        numero.setValue(RetornarNumero(response.dados.dados.endereco));
        bairro.setValue(RetornarBairro(response.dados.dados.endereco));
        municipio.setValue(RetornarMunicipio(response.dados.dados.endereco));
        estado.setValue(RetornarEstado(response.dados.dados.endereco));
        telefone.setValue(response.dados.dados.telefone);
        setDate(new Date(response.dados.dados.dataNacimento));
      } else {
        if (response.errors.length > 1) {
          setErros(response.errors);
        } else {
          setErros([response.message]);
        }
      }
    }
  }

  async function Cadastros() {
    const response = await Cadastro(
      nome.value,
      date,
      sexo.value,
      cpfEdit.value == "" ? cpf.value : cpfEdit.value,
      mae.value,
      FormatarEndereco(
        endereco.value,
        numero.value,
        bairro.value,
        municipio.value,
        estado.value
      ),
      telefone.value
    );

    if (!response.sucesso) {
      setErros(response.errors);
      settypeAlert("error");
    } else {
      setErros([response.message]);
      setTimeout(() => {
        router.push("/Adm/Pacientes/Listar");
      }, 3000);
    }
  }

  async function BuscarCep(e) {
    if (!e.target.value.includes("_")) {
      const response = await BuscaCep(e.target.value);
      endereco.setValue(response.logradouro);
      bairro.setValue(response.bairro);
      municipio.setValue(response.localidade);
      estado.setValue(response.uf);
    }
  }

  const id = Form();
  const guid = Form();
  const nome = Form();
  const cpfEdit = Form();
  const sexo = Form();
  const cpf = Form();
  const mae = Form();
  const endereco = Form();
  const numero = Form();
  const bairro = Form();
  const municipio = Form();
  const estado = Form();
  const telefone = Form();

  return (
    <>
      <div className="mt-24">
        <div className="w-full flex flex-col gap-2 md:flex-row md:justify-between lg:justify-between xl:flex-row xl:justify-between">
          <span className="text-2xl">Cadastro de pacientes</span>
        </div>
      </div>
      <div className="mt-5">
        <div id="alerta">
          {errors.map((item) => {
            <Alerta type={typeAlert} show={true}>
              {item}
            </Alerta>;
          })}
        </div>
        <div className="grid grid-cols-1 gap-5">
          <Input {...id} type={"hidden"} />
          <Input {...guid} type={"hidden"} />
          <Input {...cpfEdit} type={"hidden"} />
          <Input placeholder={"Nome completo do paciente"} {...nome} />
          {cpfEdit.value.length == 0 && (
            <InputMaks mask={"999.999.999-99"} placeholder={"CPF"} {...cpf} />
          )}

          <SelectDatas
            placeholder={"Data de nascimento"}
            value={date}
            onChange={(date) => setDate(date)}
          />
          <Select
            placeholder={"Selecione uma opção"}
            data={EnumSexo}
            {...sexo}
            selectList={["Value", "Text"]}
          />
          <InputMaks
            mask={"(99) 99999-9999"}
            placeholder={"Telefone"}
            {...telefone}
          />
          <InputMaks
            mask={"99999-999"}
            placeholder={"CEP"}
            onChange={(e) => BuscarCep(e)}
          />
          <Input placeholder={"Enderço"} {...endereco} disabled={true} />
          <Input placeholder={"Numero"} {...numero} />
          <Input placeholder={"Bairro"} {...bairro} disabled={true} />
          <Input placeholder={"Municipio"} {...municipio} disabled={true} />
          <Input placeholder={"Estado"} {...estado} disabled={true} />
        </div>
      </div>
      <div className="flex gap-5 mt-5">
        <Button onClick={Cadastros}>Cadastrar</Button>
        <Ahref link={"/Adm/Pacientes/Listar"}>Voltar</Ahref>
      </div>
    </>
  );
}

export default Cadastrar;
