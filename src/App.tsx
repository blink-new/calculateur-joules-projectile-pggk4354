import { useState, useEffect } from 'react'
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from './components/ui/card'
import { Input } from './components/ui/input'
import { Label } from './components/ui/label'
import { Button } from './components/ui/button'
import { Badge } from './components/ui/badge'
import { Separator } from './components/ui/separator'
import { Calculator, RotateCcw, Zap, Target, Gauge } from 'lucide-react'

function App() {
  const [grains, setGrains] = useState<string>('')
  const [weight, setWeight] = useState<string>('')
  const [velocity, setVelocity] = useState<string>('')
  const [energy, setEnergy] = useState<number | null>(null)
  const [isValid, setIsValid] = useState(false)

  // Calcul de l'énergie cinétique en temps réel
  useEffect(() => {
    const grainsNum = parseFloat(grains)
    const weightNum = parseFloat(weight)
    const velocityNum = parseFloat(velocity)

    if (grainsNum > 0 && weightNum > 0 && velocityNum > 0) {
      // Formule: E = 1/2 * m * v²
      // Conversion du poids en kg (supposant que le poids est en grammes)
      const massInKg = weightNum / 1000
      const energyInJoules = 0.5 * massInKg * Math.pow(velocityNum, 2)
      setEnergy(energyInJoules)
      setIsValid(true)
    } else {
      setEnergy(null)
      setIsValid(false)
    }
  }, [grains, weight, velocity])

  const handleReset = () => {
    setGrains('')
    setWeight('')
    setVelocity('')
    setEnergy(null)
    setIsValid(false)
  }

  return (
    <div className="min-h-screen bg-gradient-to-br from-slate-50 to-blue-50 p-4">
      <div className="max-w-4xl mx-auto">
        {/* Header */}
        <div className="text-center mb-8 animate-fade-in">
          <div className="flex items-center justify-center gap-3 mb-4">
            <div className="p-3 bg-primary/10 rounded-full">
              <Calculator className="h-8 w-8 text-primary" />
            </div>
            <h1 className="text-4xl font-bold text-gray-900">
              Calculateur d'énergie
            </h1>
          </div>
          <p className="text-lg text-gray-600 max-w-2xl mx-auto">
            Calculez l'énergie cinétique d'un projectile en joules à partir du nombre de grains, 
            du poids de la balle et de sa vitesse
          </p>
        </div>

        <div className="grid lg:grid-cols-2 gap-8">
          {/* Formulaire de saisie */}
          <Card className="animate-slide-up shadow-lg border-0 bg-white/80 backdrop-blur-sm">
            <CardHeader className="pb-4">
              <CardTitle className="flex items-center gap-2 text-xl">
                <Target className="h-5 w-5 text-primary" />
                Paramètres du projectile
              </CardTitle>
              <CardDescription>
                Saisissez les valeurs pour calculer l'énergie cinétique
              </CardDescription>
            </CardHeader>
            <CardContent className="space-y-6">
              {/* Nombre de grains */}
              <div className="space-y-2">
                <Label htmlFor="grains" className="text-sm font-medium flex items-center gap-2">
                  <div className="w-2 h-2 bg-primary rounded-full"></div>
                  Nombre de grains de poudre
                </Label>
                <Input
                  id="grains"
                  type="number"
                  placeholder="Ex: 42"
                  value={grains}
                  onChange={(e) => setGrains(e.target.value)}
                  className="h-12 text-lg transition-all duration-200 focus:ring-2 focus:ring-primary/20"
                />
                <p className="text-xs text-gray-500">Quantité de poudre utilisée</p>
              </div>

              {/* Poids de la balle */}
              <div className="space-y-2">
                <Label htmlFor="weight" className="text-sm font-medium flex items-center gap-2">
                  <div className="w-2 h-2 bg-accent rounded-full"></div>
                  Poids de la balle (grammes)
                </Label>
                <Input
                  id="weight"
                  type="number"
                  step="0.1"
                  placeholder="Ex: 9.5"
                  value={weight}
                  onChange={(e) => setWeight(e.target.value)}
                  className="h-12 text-lg transition-all duration-200 focus:ring-2 focus:ring-accent/20"
                />
                <p className="text-xs text-gray-500">Masse du projectile en grammes</p>
              </div>

              {/* Vitesse */}
              <div className="space-y-2">
                <Label htmlFor="velocity" className="text-sm font-medium flex items-center gap-2">
                  <div className="w-2 h-2 bg-green-500 rounded-full"></div>
                  Vitesse (m/s)
                </Label>
                <Input
                  id="velocity"
                  type="number"
                  step="0.1"
                  placeholder="Ex: 350"
                  value={velocity}
                  onChange={(e) => setVelocity(e.target.value)}
                  className="h-12 text-lg transition-all duration-200 focus:ring-2 focus:ring-green-500/20"
                />
                <p className="text-xs text-gray-500">Vitesse du projectile en mètres par seconde</p>
              </div>

              <Button 
                onClick={handleReset}
                variant="outline"
                className="w-full h-12 text-base hover:bg-gray-50 transition-all duration-200"
              >
                <RotateCcw className="h-4 w-4 mr-2" />
                Réinitialiser
              </Button>
            </CardContent>
          </Card>

          {/* Résultats */}
          <div className="space-y-6">
            {/* Carte de résultat principal */}
            <Card className="animate-slide-up shadow-lg border-0 bg-white/80 backdrop-blur-sm">
              <CardHeader className="pb-4">
                <CardTitle className="flex items-center gap-2 text-xl">
                  <Zap className="h-5 w-5 text-accent" />
                  Énergie cinétique
                </CardTitle>
                <CardDescription>
                  Résultat du calcul en temps réel
                </CardDescription>
              </CardHeader>
              <CardContent>
                {isValid && energy !== null ? (
                  <div className="text-center space-y-4">
                    <div className="p-6 bg-gradient-to-r from-primary/10 to-accent/10 rounded-xl">
                      <div className="text-4xl font-bold text-primary mb-2">
                        {energy.toFixed(2)}
                      </div>
                      <Badge variant="secondary" className="text-lg px-4 py-1">
                        Joules (J)
                      </Badge>
                    </div>
                    
                    <div className="grid grid-cols-3 gap-4 text-center">
                      <div className="p-3 bg-blue-50 rounded-lg">
                        <div className="text-sm text-gray-600">Grains</div>
                        <div className="font-semibold text-primary">{grains}</div>
                      </div>
                      <div className="p-3 bg-amber-50 rounded-lg">
                        <div className="text-sm text-gray-600">Poids</div>
                        <div className="font-semibold text-accent">{weight}g</div>
                      </div>
                      <div className="p-3 bg-green-50 rounded-lg">
                        <div className="text-sm text-gray-600">Vitesse</div>
                        <div className="font-semibold text-green-600">{velocity} m/s</div>
                      </div>
                    </div>
                  </div>
                ) : (
                  <div className="text-center py-8 text-gray-500">
                    <Gauge className="h-12 w-12 mx-auto mb-4 opacity-50" />
                    <p className="text-lg">Saisissez les valeurs pour voir le résultat</p>
                    <p className="text-sm">Le calcul se fait automatiquement</p>
                  </div>
                )}
              </CardContent>
            </Card>

            {/* Formule et informations */}
            <Card className="animate-slide-up shadow-lg border-0 bg-white/80 backdrop-blur-sm">
              <CardHeader className="pb-4">
                <CardTitle className="text-lg">Formule utilisée</CardTitle>
              </CardHeader>
              <CardContent className="space-y-4">
                <div className="p-4 bg-gray-50 rounded-lg font-mono text-center">
                  <div className="text-lg font-semibold mb-2">E = ½ × m × v²</div>
                  <Separator className="my-2" />
                  <div className="text-sm text-gray-600 space-y-1">
                    <div><strong>E</strong> = Énergie cinétique (Joules)</div>
                    <div><strong>m</strong> = Masse (kg)</div>
                    <div><strong>v</strong> = Vitesse (m/s)</div>
                  </div>
                </div>
                
                <div className="text-sm text-gray-600 space-y-2">
                  <p><strong>Note :</strong> Le poids de la balle est automatiquement converti de grammes en kilogrammes pour le calcul.</p>
                  <p><strong>Précision :</strong> Le résultat est affiché avec 2 décimales pour une lecture optimale.</p>
                </div>
              </CardContent>
            </Card>
          </div>
        </div>

        {/* Footer */}
        <div className="text-center mt-12 text-gray-500 text-sm">
          <p>Calculateur d'énergie cinétique pour projectiles • Résultats en temps réel</p>
        </div>
      </div>
    </div>
  )
}

export default App