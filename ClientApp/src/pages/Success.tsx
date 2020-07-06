import React, { useState, useEffect } from 'react'
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


  const [allegeries, setAllegeries] = useState([])
  const [conditions, setConditions] = useState([])
    const [diagnostics, setDiagnostics] = useState([])
    const [immunization, setImmunization] = useState([])
    const [medications, setMedications] = useState([])
    const [medStatement, setMedStatement] = useState([])
  const [observation, setObservation] = useState([])

  const [procedure, setProcedure] = useState([])
    
 
 
  const getProcedure = async () => {
    const resp = await axios.get(
      `/api/conditions/procedure?access_token=${accessToken}&patient=${patient}`
    )
    console.log({ resp })
    setProcedure(resp.data.entry)
  } 
  const getObservation = async () => {
    const resp = await axios.get(
      `/api/conditions/observation?access_token=${accessToken}&patient=${patient}`
    )
    console.log({ resp })
    setObservation(resp.data.entry)
  }
  const getMedStatements = async () => {
      const resp = await axios.get(
        `/api/conditions/medstatements?access_token=${accessToken}&patient=${patient}`
      )
      console.log({ resp })
      setMedStatement(resp.data.entry)
    }
    const getMedications = async () => {
      const resp = await axios.get(
        `/api/conditions/medications?access_token=${accessToken}&patient=${patient}`
      )
      console.log({ resp })
      setMedications(resp.data.entry)
    }
    const getAllergies = async () => {
    const resp = await axios.get(
      `/api/conditions/allergies?access_token=${accessToken}&patient=${patient}`
    )
    console.log({ resp })
    setAllegeries(resp.data.entry)
  }

  const getConditions = async () => {
    const resp = await axios.get(
      `/api/conditions/conditions?access_token=${accessToken}&patient=${patient}`
    )
    console.log({ resp })
    setConditions(resp.data.entry)
  }

  const getDiagnostics = async () => {
    const resp = await axios.get(
      `/api/conditions/diagnostic?access_token=${accessToken}&patient=${patient}`
    )
    console.log({ resp })
    setDiagnostics(resp.data.entry)
  }

  const getImmunization = async () => {
    const resp = await axios.get(
      `/api/conditions/immunization?access_token=${accessToken}&patient=${patient}`
    )
    console.log({ resp })
    setImmunization(resp.data.entry)
  }

  useEffect(() => {
    ;(async () => {
      await getAllergies()
      await getConditions()
      await getDiagnostics()
      await getMedications()
      await getImmunization()
      await getMedStatements()
      await getObservation()
      await getProcedure()
    })()
    
  }, [])

  return (
    <div>
      <h1>Patient : {patient}</h1>
      {/* <button onClick={getAllergiesMaybe}>Get allergies?</button> */}
      <h2>Allegories</h2>
      <ul>
        {allegeries.map((al :any) => {
        return <li key={al.resource.id}>
          {al.resource?.substance?.text}
        </li>})
      }
      </ul>
      <h2>Conditions</h2>
      <ul>
        {conditions.map((al :any) => {
        return <li key={al.resource.id}>
          {al.resource?.code?.text}
        </li>})
      }
      </ul>
      <h2>diagnostics</h2>
      <ul>
        {diagnostics.map((al :any) => {
        return <li key={al.resource.id}>
         {al.resource.code.text}
         <ul>
           {al.resource.result.map((result:any, index:number) => {
             return <li>{result.display}</li>
           })}
         </ul>
        </li>})
      }
      </ul>
      <h2>Immunizations</h2>
      <ul>
        {immunization.map((al :any) => {
        return <li key={al.resource.id}>
         {al.resource.vaccineCode.text}
        </li>})
      }
      </ul>
      <h2>Medications</h2>
      <ul>
        {medications.map((al :any) => {
        return <li key={al.resource.id}>
         {al.resource.medicationReference.display}
        </li>})
      }
      </ul>
      <h2>Med Statement</h2>
      <ul>
        {medStatement.map((al :any) => {
        return <li key={al.resource.id}>
               {al.resource.medicationReference.display}
        </li>})
      }
      </ul>
      <h2>Observation</h2>
      <ul>
        {observation.map((al :any) => {
        return <li key={al.resource.id}>
          <hr/>
          <ul>
            { al.resource.code.coding.map((code:any, index:number) => {
              return <li key={index}>{code.display}</li>
            })}
          </ul>
              
        </li>})
      }
      </ul>

      <h2>Procedures</h2>
      <ul>
        {procedure.map((al :any) => {
        return <li key={al.resource.id}>
          <hr/>
          <ul>
            { al.resource.code.coding.map((code:any, index:number) => {
              return <li key={index}>{code.display}</li>
            })}
          </ul>
              
        </li>})
      }
      </ul>
      
    </div>
  )
}

export default Success
