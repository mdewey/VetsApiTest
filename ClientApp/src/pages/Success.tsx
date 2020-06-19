import React, { useState } from 'react'
import { useLocation } from 'react-router-dom'
import axios from 'axios'
const Success = (props: any) => {
  console.log({ props })

  const params = new URLSearchParams(useLocation().search)

  for (let p of params) {
    console.log({ p })
  }

  const [accessToken, setAccessToken] = useState<string | null>(
    params.get('access_token')
  )
  const [patient, setPatient] = useState<string | null>(params.get('patient'))

  const getAllergiesMaybe = async () => {
    const resp = await axios.get(
      `/api/conditions/allergies?access_token=${accessToken}&patient=${patient}`
    )
    console.log({ resp })
  }

  return (
    <div>
      <h1>Patient : {patient}</h1>
      <button onClick={getAllergiesMaybe}>Get allergies?</button>
    </div>
  )
}

export default Success
