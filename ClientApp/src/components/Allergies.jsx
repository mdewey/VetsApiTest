import React, { useState } from 'react'
import RawView from './RawView'

export default function Allergies(props) {
  const { substance, note, reaction } = props.resource

  return (
    <div>
      <hr />
      <h3>{substance.text}</h3>
      <section>
        <div>when - {new Date(note.time).toString()}</div>
        <div>reactions</div>
        <ul>
          {reaction.map(r => {
            return (
              <li>
                {r.certainty} |
                {r.manifestation.map(man => {
                  return (
                    <div>
                      {man.coding.map(code => {
                        return <div>{code.display}</div>
                      })}
                    </div>
                  )
                })}
              </li>
            )
          })}
        </ul>
      </section>
      <RawView json={props.resource} />
    </div>
  )
}
